using ComputationGeometry.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputationGeometry
{
    internal static class Compute
    {
        public enum Orientation
        {
            Collinear = 0,
            Left = 1,
            Right = 2
        }
        public static double Tolerance = 1e-10;
        /// <summary>
        /// 获取向量v1和v2的方向关系
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Orientation GetOrientationOfVectors(Vector2d v1, Vector2d v2)
        {
            double crossProduct = v1.X * v2.Y - v1.Y * v2.X;
            if (Math.Abs(crossProduct) < Tolerance)
            {
                return Orientation.Collinear;
            }
            else if (crossProduct > 0)
            {
                return Orientation.Left;
            }
            else
            {
                return Orientation.Right;
            }
        }
    }
}
