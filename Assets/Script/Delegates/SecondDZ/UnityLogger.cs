using System;
using System.Collections.Generic;
using UnityEngine;

public class UnityLogger : MonoBehaviour
{
    public void Log(string message)
    {
        Debug.Log(message);
    }
	
    public void LogCollection(IEnumerable<string> strs, Action<string> logAction)
    {
        foreach (string str in strs)
        {
            logAction(str);
        }
    }
}
