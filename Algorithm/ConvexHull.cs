using ComputationGeometry.Class;
using System;
using System.Collections.Generic;
using System.Text;

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
            QuickSortByX(points);


        }
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="points"></param>
        private static void QuickSortByX(List<Point2d> points)
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
        /// 排序子任务
        /// </summary>
        /// <param name="points"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static int Partition(List<Point2d> points, int left, int right)
        {
            double pivot = points[right].X;
            int startIndex = left;
            for (int i = 0; i < points.Count; i++)
            {
                double curX = points[i].X;
                if (curX < pivot)
                {
                    (points[i], points[startIndex]) = (points[startIndex], points[i]);
                    startIndex++;
                }
            }
            (points[startIndex], points[right]) = (points[right], points[startIndex]);
            return startIndex + 1;
        }
    }
}
