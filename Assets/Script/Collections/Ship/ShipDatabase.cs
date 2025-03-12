using System.Collections.Generic;
using UnityEngine;

public class ShipDatabase
{
    private Dictionary<int, ShipType> _shipTypes = new ();

    public IReadOnlyDictionary<int, ShipType> ShipTypes => _shipTypes;

    public void InitializeDatabase()
    {
        _shipTypes = new Dictionary<int, ShipType>();
        
        ShipType scout = ScriptableObject.CreateInstance<ShipType>();
        scout.Initialize(0, 1f, 50, 100);
        
        ShipType fighter = ScriptableObject.CreateInstance<ShipType>();
        fighter.Initialize(1, 8f, 100, 200);
        
        ShipType cruiser = ScriptableObject.CreateInstance<ShipType>();
        cruiser.Initialize(7, 5f, 300, 500);
    
        _shipTypes.Add(scout.ID, scout);
        _shipTypes.Add(fighter.ID, fighter);
        _shipTypes.Add(cruiser.ID, cruiser);
    }
}
