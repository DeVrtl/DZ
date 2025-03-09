using System;

namespace FouthTask
{
    public struct Point : IMoveable
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point other)
        {
            return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
        }
    
        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }
}