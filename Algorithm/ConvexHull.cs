using ComputationGeometry.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ComputationGeometry.Compute;

namespace ComputationGeometry.Algorithm
{
    internal class ConvexHull
    {

        /// <summary>
        /// 求二维点集凸包
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static List<Point2d> GetConvexHull(List<Point2d> points)
        {
            if (points?.Count < 3) 
            {
                throw new ArgumentException("Convex hull requires at least 3 points.");
            }
            //按照x排序
            QuickSortByX(points);
            List<Point2d> upConvexHull = [ points[0], points[1] ];

            for (int i = 2; i < points.Count; i++)
            {
                Point2d nextP = points[i];
                int count = upConvexHull.Count;
                Vector2d curV = upConvexHull[count - 1] - upConvexHull[count - 2];
                Vector2d nextV = nextP - upConvexHull[count - 1];
                Orientation orientation = Compute.GetOrientationOfVectors(curV, nextV);
                if (!orientation.Equals(Orientation.Right))
                {
                    upConvexHull.Remove(upConvexHull.Last());

                }


            }

        }
        /// <summary>
        /// 快速排序非递归实现
        /// </summary>
        /// <param name="points"></param>
        private static void QuickSortByX_NonRecursive(List<Point2d> points)
        {
            if (points?.Count <= 1) return;
            Stack<(int left, int right)> taskStack = new();
            taskStack.Push((0, points.Count - 1));

            while (taskStack.Count > 0)
            {
                int left, right;
                (left, right) = taskStack.Pop();
                if (left >= right)
                {
                    continue;
                }
                int pivotIndex = Partition(points, left, right);
                taskStack.Push((left, pivotIndex - 1));
                taskStack.Push((pivotIndex + 1, right));
            }
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        private static void QuickSortByX(List<Point2d> points, int left = 0, int right = -1)
        {
            if (points.Count <= 1) return;

            if (right == -1) right = points.Count - 1;

            int povitIndex = Partition(points, left, right);
            QuickSortByX(points, left, povitIndex - 1);
            QuickSortByX(points, povitIndex + 1, right);
        }

        /// <summary>
        /// 快速排序子任务
        /// </summary>
        /// <param name="points"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static int Partition(List<Point2d> points, int left, int right)
        {
            double pivot = points[right].X;
            int startIndex = left;
            for (int i = left; i < right; i++)
            {
                double curX = points[i].X;
                if (curX < pivot)
                {
                    (points[i], points[startIndex]) = (points[startIndex], points[i]);
                    startIndex++;
                }
            }
            (points[startIndex], points[right]) = (points[right], points[startIndex]);
            return startIndex;
        }
    }
}
