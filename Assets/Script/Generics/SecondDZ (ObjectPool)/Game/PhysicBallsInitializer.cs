using UnityEngine;

public class PhysicBallsInitializer : MonoBehaviour
{
    [field: SerializeField] public ObjectPool<GameObject> PoolOfPhysicsBalls { get; private set; }
    
    private void Awake()
    {
        PoolOfPhysicsBalls.Construct(
            () => Instantiate(PoolOfPhysicsBalls.ObjectPrefab),
            b => b.activeSelf,
            b => Destroy(b),
            b => b.SetActive(false));
        
        PoolOfPhysicsBalls.Init();
    }
}