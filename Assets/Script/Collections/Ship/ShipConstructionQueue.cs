using System.Collections.Generic;
using UnityEngine;

public class ShipConstructionQueue : MonoBehaviour
{
    [SerializeField] private ShipConstructionHistory _constructionHistory;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerFleet _playerFleet;
    [SerializeField] private ShipDatabase _database;
    
    private Queue<int> _contructionQueue = new ();

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
            
            bool canAddShip = _playerFleet.AddToFleet(id);

            if (canAddShip != true) 
                return;
                
            _player.Buy(ship.Cost);

            Debug.Log($"Ship {id} was build and you have {_player.Money} resources");
            
            _constructionHistory.Add(id);
        }
    }
}
