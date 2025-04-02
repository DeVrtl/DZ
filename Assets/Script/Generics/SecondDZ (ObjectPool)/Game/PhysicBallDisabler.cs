using UnityEngine;

public class PhysicBallDisabler : MonoBehaviour
{
    [SerializeField] private PhysicBallsInitializer _physicBallsInitializer;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Rigidbody2D objectInTrigger))
        {
            _physicBallsInitializer.PoolOfPhysicsBalls.Deinit(objectInTrigger.gameObject);
        }
    }
}
