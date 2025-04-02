using UnityEngine;
using System.Collections;
using InfimaGames.LowPolyShooterPack;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour {

	[Range(5, 100)]
	[Tooltip("After how long time should the bullet prefab be destroyed?")]
	public float destroyAfter;
	[Tooltip("If enabled the bullet destroys on impact")]
	public bool destroyOnImpact = false;
	[Tooltip("Minimum time after impact that the bullet is destroyed")]
	public float minDestroyTime;
	[Tooltip("Maximum time after impact that the bullet is destroyed")]
	public float maxDestroyTime;

	private void Start ()
	{
		var gameModeService = ServiceLocator.Current.Get<IGameModeService>();
		Physics.IgnoreCollision(gameModeService.GetPlayerCharacter().GetComponent<Collider>(), GetComponent<Collider>());

		StartCoroutine (DestroyAfter ());
	}
	
	private void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.GetComponent<Projectile>() != null)
			return;
		
		if (!destroyOnImpact) 
		{
			StartCoroutine(DestroyTimer ());
		}
		else 
		{
			Destroy(gameObject);
		}

		IHaveProjectileReaction reaction = collision.gameObject.GetComponent<IHaveProjectileReaction>();
		if (reaction != null)
		{
			if (reaction is IHaveProjectileCollisionReaction collisionReaction)
			{
				collisionReaction.ReactWithCollision(collision);
			}
			else
			{
				reaction.React();
			}
			
			Destroy(gameObject);
		}
	}

	private IEnumerator DestroyTimer () 
	{
		yield return new WaitForSeconds(Random.Range(minDestroyTime, maxDestroyTime));
		Destroy(gameObject);
	}

	private IEnumerator DestroyAfter () 
	{
		yield return new WaitForSeconds(destroyAfter);
		Destroy(gameObject);
	}
}