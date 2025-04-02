using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour, IHaveProjectileReaction 
{
	
	[Header("Customizable Options")]
	[SerializeField] private float _minTime;
	[SerializeField] private float _maxTime;

	[Header("Audio")]
	[SerializeField] private AudioClip _upSound;
	[SerializeField] private AudioClip _downSound;
	[SerializeField] private AudioSource _audioSource;

	[Header("Animations")] 
	[SerializeField] private Animation _animation;
	[SerializeField] private AnimationClip _targetUp;
	[SerializeField] private AnimationClip _targetDown;
	
	private float _randomTime;
	private bool _routineStarted = false;
	private bool _isHit = false;

	public bool IsHit => _isHit;
	
	private IEnumerator DelayTimer () 
	{
		yield return new WaitForSeconds(_randomTime);
		_animation.clip = _targetUp;
		_animation.Play();
		
		_audioSource.clip = _upSound;
		_audioSource.Play();
		
		_isHit = false;
		_routineStarted = false;
	}

	public void React()
	{
		_isHit = true;
		_randomTime = Random.Range (_minTime, _maxTime);
		
		if (_routineStarted == false) 
		{
			_animation.clip = _targetDown;
			_animation.Play();
			
			_audioSource.clip = _downSound;
			_audioSource.Play();
			
			StartCoroutine(DelayTimer());
			_routineStarted = true;
		} 
	}
}