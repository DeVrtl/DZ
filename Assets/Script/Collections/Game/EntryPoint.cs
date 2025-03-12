using System;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private Player _player;
    private PlayerFleet _fleet;
    private ShipDatabase _shipDatabase;
    private ShipConstructionQueue _shipConstruction;
    private ShipConstructionHistory _constructionHistory;

    public Action<ShipConstructionQueue, ShipConstructionHistory> ConstructionInitialized;
    public Action<ShipDatabase, PlayerFleet> FleetInitialized;
    
    private void Start()
    {
        _player = new Player();
        _fleet = new PlayerFleet();
        _shipDatabase = new ShipDatabase();
        
        _shipDatabase.InitializeDatabase();

        _constructionHistory = new ShipConstructionHistory(_player, _fleet, _shipDatabase);
        _shipConstruction = new ShipConstructionQueue(_player, _fleet, _constructionHistory, _shipDatabase);
        
        ConstructionInitialized?.Invoke(_shipConstruction, _constructionHistory);
        FleetInitialized?.Invoke(_shipDatabase, _fleet);
    }
}
