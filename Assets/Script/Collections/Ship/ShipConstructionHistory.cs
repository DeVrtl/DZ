using System.Collections.Generic;
using UnityEngine;

public class ShipConstructionHistory : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerFleet _fleet;
    [SerializeField] private ShipDatabase _database;
    
    private Stack<int> _buildHistory = new ();

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