using UnityEngine;

public class TestHashSetUsage : MonoBehaviour
{
    [SerializeField] private ShipDatabase _database;
    [SerializeField] private PlayerFleet playerFleet;
    
    private void Start()
    {
        foreach (var ship in _database.ShipTypes)
        {
            playerFleet.AddToFleet(ship.Key);
        }
        
        foreach (var ship in _database.ShipTypes)
        {
            playerFleet.AddToFleet(ship.Key);
        }
    }
}
