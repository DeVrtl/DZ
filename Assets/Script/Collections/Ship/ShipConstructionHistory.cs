using System.Collections.Generic;
using UnityEngine;

public class ShipConstructionHistory
{
    private readonly Player _player;
    private readonly PlayerFleet _fleet;
    private readonly ShipDatabase _database;
    
    private readonly Stack<int> _buildHistory = new ();

    public ShipConstructionHistory(Player player, PlayerFleet fleet, ShipDatabase database)
    {
        _player = player;
        _fleet = fleet;
        _database = database;
    }
    
    public void Add(int id)
    {
        _buildHistory.Push(id);
    }

    public void UnloadLastBuild()
    {
        if (_buildHistory.Count != 0)
        {
            int id = _buildHistory.Pop();
            
            _fleet.RemoveFromFleet(id);
            
            if (!_database.ShipTypes.TryGetValue(id, out ShipType ship))
                return;
                
            _player.AddMoney(ship.Cost);
            
            Debug.Log($"Canceled ship construction: {id}, Resources returned: {ship.Cost}");
        }
    }
}