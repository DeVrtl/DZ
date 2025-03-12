using System;
using UnityEngine;

public class ConsturctionTest : MonoBehaviour
{
    [SerializeField] private EntryPoint _entryPoint;
    
    private ShipConstructionQueue _shipConstruction;
    private ShipConstructionHistory _constructionHistory;

    private void OnEnable()
    {
        _entryPoint.ConstructionInitialized += OnConstructionInitialized;
    }

    private void OnDisable()
    {
        _entryPoint.ConstructionInitialized -= OnConstructionInitialized;
    }

    private void OnConstructionInitialized(ShipConstructionQueue shipConstruction, ShipConstructionHistory constructionHistory)
    {
        _shipConstruction = shipConstruction;
        _constructionHistory = constructionHistory;
        
        _shipConstruction.EnqueueShipToBuild(0);
        _shipConstruction.EnqueueShipToBuild(1);
        _shipConstruction.EnqueueShipToBuild(7);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _constructionHistory.UnloadLastBuild();
        }
    }
}
