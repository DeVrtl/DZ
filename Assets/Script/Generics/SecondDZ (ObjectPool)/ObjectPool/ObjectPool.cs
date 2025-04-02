using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> : IPoolObject<T>
{
    private List<T> _listOfObjects = new ();
    private Func<T> _instantiate;
    private Func<T, bool> _isActive;
    private Action<T> _destroy;
    private Action<T> _disable;
    private Action<T> _reset;

    public ObjectPool(Func<T> instantiate, Func<T, bool> isActive, Action<T> destroy, Action<T> disable, Action<T> reset)
    {
        _instantiate = instantiate;
        _isActive = isActive;
        _destroy = destroy;
        _disable = disable;
        _reset = reset;
    }
    
    public T PullOrCreate()
    {
        T match = _listOfObjects.FirstOrDefault(o => !_isActive(o));

        if (match != null) 
            return match;
        
        T instantiatedObject = _instantiate();
        _listOfObjects.Add(instantiatedObject);
        return instantiatedObject;
    }

    public void Init(T objectToPool, int count)
    {
        for (int i = 0; i < count; i++)
        {
            objectToPool = _instantiate();
            _listOfObjects.Add(objectToPool);
            _disable(objectToPool);
        }
    }
    
    public void Deinit(T objectToReturn)
    {
        if (objectToReturn != null && _listOfObjects.Contains(objectToReturn))
        {
            _listOfObjects.Add(objectToReturn);
            Reset(objectToReturn);
            _disable(objectToReturn);
        }
    }
    
    public void ClearPool()
    {
        foreach (var objectToRemove in _listOfObjects.ToList())
        {
            _listOfObjects.Remove(objectToRemove);
            _destroy(objectToRemove);
        }
    }
    
    private void Reset(T objectToReset)
    {
        _reset(objectToReset);
    }
}
