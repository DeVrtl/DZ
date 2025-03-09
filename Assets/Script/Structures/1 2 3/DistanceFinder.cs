using UnityEngine;

namespace FirstTask
{
    public class DistanceFinder : MonoBehaviour
    {
        private Point _point1 = new Point(0, 0);
        private Point _point2 = new Point(3, 4);

        private void Start()
        {
            Debug.Log(_point1.DistanceTo(_point2));
            Debug.Log(_point2.DistanceTo(_point1));
        }
    }
}