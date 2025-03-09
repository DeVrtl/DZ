using UnityEngine;

namespace FouthTask
{
    public class MovePoint : MonoBehaviour
    {
        private Point _point;
        private IMoveable _moveable = new Point(0, 0); 
        
        private void Start()
        {
            Debug.Log(_point.X);
            Debug.Log(_point.Y);
            _moveable.Move(1, 1);

            _point = (Point)_moveable;
            
            Debug.Log(_point.X);
            Debug.Log(_point.Y);
        }
    }
}


