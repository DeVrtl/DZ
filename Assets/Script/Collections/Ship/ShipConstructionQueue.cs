using System.Collections.Generic;
using UnityEngine;

public class ShipConstructionQueue
{
    private readonly Player _player;
    private readonly PlayerFleet _fleet;
    private readonly ShipConstructionHistory _constructionHistory;
    private readonly ShipDatabase _database;
    
    private readonly Queue<int> _contructionQueue = new ();

    public ShipConstructionQueue(Player player, PlayerFleet fleet, ShipConstructionHistory constructionHistory, ShipDatabase database)
    {
        _player = player;
        _fleet = fleet;
        _constructionHistory = constructionHistory;
        _database = database;
    }
    
    public void EnqueueShipToBuild(int shipId)
    {
        _contructionQueue.Enqueue(shipId);
        Debug.Log($"Added to construction Queue: {shipId}");
        BuildNextShip();
    }

    private void BuildNextShip()
    {
        if (_contructionQueue.Count != 0)
        {
            int id = _contructionQueue.Dequeue();

            if (!_database.ShipTypes.TryGetValue(id, out ShipType ship))
                return;
            
            bool canAddShip = _fleet.AddToFleet(id);

            if (canAddShip != true) 
                return;
                
            _player.Buy(ship.Cost);

            Debug.Log($"Ship {id} was build and you have {_player.Money} resources");
            
            _constructionHistory.Add(id);
        }
    }
}
