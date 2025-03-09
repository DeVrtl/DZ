using System;
using UnityEngine;

public class ConsturctionTest : MonoBehaviour
{
    [SerializeField] private ShipConstructionQueue _shipConstruction;
    [SerializeField] private ShipConstructionHistory _constructionHistory;
    
    private void Start()
    {
        _shipConstruction.EnqueueShipToBuild(0);
        _shipConstruction.EnqueueShipToBuild(1);
        _shipConstruction.EnqueueShipToBuild(7);
        
        _shipConstruction.EnqueueShipToBuild(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _constructionHistory.UnloadLastBuild();
        }
    }
}
