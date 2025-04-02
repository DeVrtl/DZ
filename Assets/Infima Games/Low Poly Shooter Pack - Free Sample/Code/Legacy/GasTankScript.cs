using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class GasTankScript : MonoBehaviour, IHaveProjectileReaction 
{
	[Header("Prefabs")]
	[SerializeField] private Transform _explosionPrefab;
	[SerializeField] private Transform _destroyedGasTankPrefab;

	[Header("Customizable Options")]
	[SerializeField] private float _explosionTimer;
	[SerializeField] private float _rotationSpeed;
	[SerializeField] private float _maxRotationSpeed;
	[SerializeField] private float _moveSpeed;
	[SerializeField] private float _audioPitchIncrease = 0.5f;

	[Header("Explosion Options")]
	[SerializeField] private float _explosionRadius = 12.5f;
	[SerializeField] private float _explosionForce = 4000.0f;

	[Header("Light")]
	[SerializeField] private Light _lightObject;

	[Header("Particle Systems")]
	[SerializeField] private ParticleSystem _flameParticles;
	[SerializeField] private ParticleSystem _smokeParticles;

	[Header("Audio")]
	[SerializeField] private AudioSource _flameSound;
	[SerializeField] private AudioSource _impactSound;
	
	[Header("Physics")]
	[SerializeField] private Rigidbody _rigidbody;
	
	private bool _audioHasPlayed = false;
	private float _randomRotationValue;
	private float _randomValue;
	private bool _routineStarted = false;
	
	private void Start () 
	{
		_lightObject.intensity = 0;
		_randomValue = Random.Range (-50, 50);
	}

	private void OnCollisionEnter (Collision collision) 
	{
		_impactSound.Play ();
	}

	private IEnumerator Explode ()
	{
		yield return new WaitForSeconds(_explosionTimer);
		
		Instantiate (_destroyedGasTankPrefab, transform.position, transform.rotation); 
		
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, _explosionRadius);
		foreach (Collider hit in colliders) 
		{
			if (_rigidbody != null)
				_rigidbody.AddExplosionForce (_explosionForce * 50, explosionPos, _explosionRadius);
			
			hit.gameObject.GetComponent<IHaveProjectileReaction>()?.React();
		}
		
		Instantiate (_explosionPrefab, transform.position, transform.rotation); 

		Destroy (gameObject);
	}

	private IEnumerator MoveAndRotateRoutine()
	{
		while (true)
		{
			_randomRotationValue += 1.0f * Time.deltaTime;
			
			if (_randomRotationValue > _maxRotationSpeed)
			{
				_randomRotationValue = _maxRotationSpeed;
			}
			
			_rigidbody.AddRelativeForce(Vector3.down * _moveSpeed * 50 * Time.deltaTime);
			
			transform.Rotate(_randomRotationValue, 0, _randomValue * _rotationSpeed * Time.deltaTime);

			yield return null;
		}
	}
	
	public void React()
	{
		StartCoroutine(MoveAndRotateRoutine());

		_flameParticles.Play ();
		_smokeParticles.Play ();
		
		_flameSound.pitch += _audioPitchIncrease * Time.deltaTime;
		
		if (!_audioHasPlayed) 
		{
			_flameSound.Play ();
			_audioHasPlayed = true;
		}

		if (_routineStarted == false) 
		{
			StartCoroutine(Explode());
			_routineStarted = true;
			_lightObject.intensity = 3;
		}
	}
}