using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoggerWrapper : MonoBehaviour
{ 
   [SerializeField] private UnityLogger logger;

   public UnityLogger Logger => logger;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Z))
      {
         List<string> stringsList = new List<string>() { "STR", "StringTwo", "StringThree" };
         string[] stringsArray = new string[] { "STRARR", "StringArrTwo" };
         IEnumerable<string> onlyUpperCase = stringsList.Where(str => str.All(ch => char.IsUpper(ch))); // выбираем те строки, где символы в upperCase
         Logger.LogCollection(stringsList, s => logger.Log(s));
         Logger.LogCollection(stringsArray, s => logger.Log(s));
         Logger.LogCollection(onlyUpperCase, s => logger.Log(s));
      }
   }
}
