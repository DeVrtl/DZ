using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomNumbersMessSort : MonoBehaviour
{
    private List<int> _numbers = new ();
    private List<int> _anotherNumbersMess = new ();
    private int _numberThatCanDivideByFive;
    private int _positiveNumber;
    private bool _isAllNumbersPositive = false;
    
    private void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            int randomInt = Random.Range(-100, 100);
            _numbers.Add(randomInt);
        }

        IEnumerable<int> numbersThatGrateThanTen = _numbers.Where(n => n > 10).Distinct();
        
        _numberThatCanDivideByFive = _numbers.FirstOrDefault(n => n % 5 == 0);
        _positiveNumber = _numbers.FirstOrDefault(n => n > 0);

        _isAllNumbersPositive = _numbers.All(n => n > 0);

        _anotherNumbersMess = numbersThatGrateThanTen.ToList();
        _anotherNumbersMess.Add(_numberThatCanDivideByFive);
        _anotherNumbersMess.Add(_positiveNumber);
        
        foreach (var number in _anotherNumbersMess)
        {
            Debug.Log(number);
        }
        
        Debug.Log(_isAllNumbersPositive);
    }
}
