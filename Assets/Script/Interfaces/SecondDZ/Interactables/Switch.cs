using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Switch");
    }
}
