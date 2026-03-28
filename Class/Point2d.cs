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
    }
}
