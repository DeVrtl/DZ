using System;
using UnityEngine;

public class DbInit : MonoBehaviour
{
    [SerializeField] private ShipDatabase _db;
    
    private void Awake()
    {
        _db.InitializeDatabase();
    }
}
