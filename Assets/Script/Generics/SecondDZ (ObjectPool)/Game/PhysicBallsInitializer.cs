using UnityEngine;

public class PhysicBallsInitializer : MonoBehaviour
{
    [SerializeField] private GameObject _physicsBall;
    [SerializeField] private int _count;

    private Vector3 _spawnPointPosition;
    
    public ObjectPool<GameObject> PoolOfPhysicsBalls { get; private set; }
    
    private void Awake()
    {
        PoolOfPhysicsBalls = new ObjectPool<GameObject>(
            () => Instantiate(_physicsBall),
            b => b.activeSelf,
            b => Destroy(b),
            b => b.SetActive(false),
            b =>
            {
                // reset example, you can reset the object's parameters here, but since this object doesn't have any, I'll leave this blank
            });
        
        PoolOfPhysicsBalls.Init(_physicsBall, _count);
    }
}