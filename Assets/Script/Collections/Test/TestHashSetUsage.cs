using UnityEngine;

public class TestHashSetUsage : MonoBehaviour
{
    [SerializeField] private EntryPoint _entryPoint;

    private ShipDatabase _database;
    private PlayerFleet _fleet;

    private void OnEnable()
    {
        _entryPoint.FleetInitialized += OnFleetInitialized;
    }

    private void OnDisable()
    {
        _entryPoint.FleetInitialized += OnFleetInitialized;
    }

    private void OnFleetInitialized(ShipDatabase database, PlayerFleet fleet)
    {
        _database = database;
        _fleet = fleet;
        
        foreach (var ship in _database.ShipTypes)
        {
            _fleet.AddToFleet(ship.Key);
        }
    }
}
