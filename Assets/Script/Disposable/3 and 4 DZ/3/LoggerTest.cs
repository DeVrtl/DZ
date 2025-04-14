using UnityEngine;

public class LoggerTest : MonoBehaviour
{
    private void Start()
    {
        using (var logger = new FileLogger("log.txt"))
        {
            logger.Log("Игра запущена");
        }
    }
}
