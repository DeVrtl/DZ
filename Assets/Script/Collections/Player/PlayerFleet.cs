using System.Collections.Generic;
using UnityEngine;

public class PlayerFleet : MonoBehaviour
{
    private HashSet<int> _shipsId = new ();
    
    public bool AddToFleet(int shipId)
    {
        bool resualt = _shipsId.Add(shipId);

        if (resualt == false)
        {
            Debug.LogWarning($"You are adding an existing ship ID to the collection: {shipId}");
        }
        else
        {
            Debug.Log($"A ship has been added to the fleet: {shipId}");
        }

        return resualt;
    }

    public void RemoveFromFleet(int shipId)
    {
        if (_shipsId.Contains(shipId))
            _shipsId.Remove(shipId);
    }
}
