using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DZ.Interfaces
{
    public class LoggerWrapper : MonoBehaviour
    {
        private UnityLogger logger = new();

        public UnityLogger Logger => logger;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                List<string> stringsList = new List<string>() { "STR", "StringTwo", "StringThree" };
                string[] stringsArray = new string[] { "STRARR", "StringArrTwo" };
                IEnumerable<string> onlyUpperCase = stringsList.Where(str => str.All(ch => char.IsUpper(ch)));
                Logger.LogCollection(stringsList);
                Logger.LogCollection(stringsArray);
                Logger.LogCollection(onlyUpperCase);
            }
        }
    }
}