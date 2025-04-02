using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DZ.Interfaces
{
    public class UnityLogger : MonoBehaviour
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }
	
        public void LogCollection(IEnumerable<string> strs)
        {
            foreach (string str in strs)
            {
                Log(str);
            }
        }
    }
}