using UnityEngine;

public class PhysicBallDisabler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Rigidbody2D objectInTrigger))
        {
            objectInTrigger.gameObject.SetActive(false);
        }
    }
}
