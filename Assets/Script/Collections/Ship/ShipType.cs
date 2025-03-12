using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipType", menuName = "ScriptableObjects/ShipType", order = 1)]
public class ShipType : ScriptableObject
{
    public int ID { get; private set; }
    public float Speed { get; private set; }
    public int Armor { get; private set; }
    public int Cost { get; private set; }

    private bool _isInitialized = false;

    public void Initialize(int id, float speed, int armor, int cost)
    {
        if (_isInitialized == true)
            throw new InvalidOperationException("Ship is already initialized");
        
        ID = id;
        Speed = speed;
        Armor = armor;
        Cost = cost;

        _isInitialized = true;
    }
}
