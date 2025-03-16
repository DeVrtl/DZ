using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ObjectPool<T> : IPoolObject
{
    [SerializeField] private T _objectPrefab;
    [SerializeField] private int _objectsCount;
    
    private List<T> _listOfObjects = new ();
    private Func<T> _instantiate;
    private Func<T, bool> _isActive;
    private Action<T> _destroy;
    private Action<T> _disable;

    public T ObjectPrefab => _objectPrefab;
    
    public void Construct(Func<T> instantiate, Func<T, bool> isActive, Action<T> destroy, Action<T> disable)
    {
        _instantiate = instantiate;
        _isActive = isActive;    
        _destroy = destroy;
        _disable = disable;
    }
    
    public T PullObject()
    {
        T pullObject = _listOfObjects.FirstOrDefault(o => !_isActive(o));

        if (pullObject == null)
        {
            T instantiatedObject = _instantiate();
            _listOfObjects.Add(instantiatedObject);

            return instantiatedObject;
        }
        
        return pullObject;
    }

    public void Init()
    {
        for (int i = 0; i < _objectsCount; i++)
        {
           T instantiatedObject = _instantiate();
           _listOfObjects.Add(instantiatedObject);
           _disable(instantiatedObject);
        }
    }

    public void Deinti()
    {
        foreach (var objectToRemove in _listOfObjects.ToList())
        {
            _listOfObjects.Remove(objectToRemove);
            _destroy(objectToRemove);
        }
    }
}
