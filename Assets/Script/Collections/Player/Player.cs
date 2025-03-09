using UnityEngine;

public class Player : MonoBehaviour
{
    public int Money { get; private set; } = 999999;

    public void Buy(int value)
    {
        if (value > Money)
        {
            Debug.Log("Not enough");
            return;
        }
        
        Money -= value;
    }

    public void AddMoney(int value)
    {
        Money += value;
    }
}
