using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicBallsSpawner : MonoBehaviour
{
    [SerializeField] private PhysicBallsInitializer _physicBallsInitializer;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _timeBetweenSpawn;
    
    private float _elapsedTime = 0;
    
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeBetweenSpawn)
        {
            _elapsedTime = 0;

            GameObject ball = _physicBallsInitializer.PoolOfPhysicsBalls.PullObject();
            ball.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
            ball.SetActive(true);
        }
    }
}
