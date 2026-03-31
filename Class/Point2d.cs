using System;
using System.Collections.Generic;
using System.Text;

namespace ComputationGeometry.Class
{
    internal class Point2d
    {
        private double _x = 0;
        private double _y = 0;
        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
        public static Vector2d operator -(Point2d p1, Point2d p2)
        {
            return new() 
            { 
                X = p2.X - p1.X,
                Y = p2.Y - p1.Y
            };

        }
    }
}
