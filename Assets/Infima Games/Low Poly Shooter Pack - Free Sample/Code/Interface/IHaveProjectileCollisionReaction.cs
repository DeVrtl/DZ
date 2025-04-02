using UnityEngine;

public interface IHaveProjectileCollisionReaction : IHaveProjectileReaction
{
    void ReactWithCollision(Collision collision);
}
