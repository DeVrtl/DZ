using UnityEngine;

public class StatsHolder : MonoBehaviour
{
    [SerializeField] private Range<float> _damageRange;
    [SerializeField] private Range<float> _healthRange;
    [SerializeField] private Range<int> _levelRange; 

    private void Start()
    {
        print($"{Random.Range(_damageRange.minValue, _damageRange.maxValue)}");
        print($"{Random.Range(_healthRange.minValue, _healthRange.maxValue)}");
        print($"{Random.Range(_levelRange.minValue, _levelRange.maxValue)}");
    }
}