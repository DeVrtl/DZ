using UnityEngine;

public class ConcreteWallReaction : MonoBehaviour, IHaveProjectileCollisionReaction
{
    public Transform []	concreteImpactPrefabs;
    
    public void ReactWithCollision(Collision collision)
    {
        Instantiate(concreteImpactPrefabs[Random.Range(0, concreteImpactPrefabs.Length)], collision.contacts[0].point, Quaternion.LookRotation(collision.contacts [0].normal));
    }
}
