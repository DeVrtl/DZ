using UnityEngine;

public class PlayerInteractRay : MonoBehaviour
{
    private Ray _ray;
    
    private void Update()
    {
        _ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }
}
