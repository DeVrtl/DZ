using UnityEngine;
using System.Collections;

public class ExplosiveBarrelScript : MonoBehaviour, IHaveProjectileReaction 
{
	[Header("Prefabs")]
	[SerializeField] private Transform _explosionPrefab;
	[SerializeField] private Transform _destroyedBarrelPrefab;

	[Header("Customizable Options")]
	[SerializeField] private float _minTime = 0.05f;
	[SerializeField] private float _maxTime = 0.25f;

	[Header("Explosion Options")]
	[SerializeField] private float _explosionRadius = 12.5f;
	[SerializeField] private float _explosionForce = 4000.0f;
	
	[Header("Physics")]
	[SerializeField] private Rigidbody _rigidbody;
	
	private float _randomTime;
	private bool _routineStarted = false;

	private IEnumerator Explode () 
	{
		yield return new WaitForSeconds(_randomTime);
		
		Instantiate(_destroyedBarrelPrefab, transform.position, transform.rotation); 

		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, _explosionRadius);
		
		foreach (Collider hit in colliders) 
		{
			_rigidbody.AddExplosionForce (_explosionForce * 50, explosionPos, _explosionRadius);
			
			hit.gameObject.GetComponent<IHaveProjectileReaction>()?.React();
		}

		RaycastHit checkGround;
		if (Physics.Raycast(transform.position, Vector3.down, out checkGround, 50))
		{
			Instantiate(_explosionPrefab, checkGround.point, Quaternion.FromToRotation (Vector3.forward, checkGround.normal)); 
		}
		
		Destroy(gameObject);
	}

	public void React()
	{
		_randomTime = Random.Range (_minTime, _maxTime);
		
		if (_routineStarted == false) 
		{
			StartCoroutine(Explode());
			_routineStarted = true;
		} 
	}
}