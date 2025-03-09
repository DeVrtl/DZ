using System.Collections.Generic;
using UnityEngine;

public class ShipDatabase : MonoBehaviour
{
    private Dictionary<int, ShipType> _shipTypes = new ();

    public IReadOnlyDictionary<int, ShipType> ShipTypes => _shipTypes;
    
    public void InitializeDatabase()
    {
        _shipTypes = new Dictionary<int, ShipType>();
        ShipType scout = new ShipType() { ID = 0, Speed = 10f, Armor = 50, Cost = 100 };
        ShipType fighter = new ShipType() { ID = 1, Speed = 8f, Armor = 100, Cost = 200 };
        ShipType cruiser = new ShipType() { ID = 7, Speed = 5f, Armor = 300, Cost = 500 };
    
        _shipTypes.Add(scout.ID, scout);
        _shipTypes.Add(fighter.ID, fighter);
        _shipTypes.Add(cruiser.ID, cruiser);
    }
}
