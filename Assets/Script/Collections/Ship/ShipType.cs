using UnityEngine;

[CreateAssetMenu(fileName = "ShipType", menuName = "ScriptableObjects/ShipType", order = 1)]
public class ShipType : ScriptableObject
{
    public int ID;
    public float Speed;
    public int Armor;
    public int Cost;
}
