using System;
using System.Collections.Generic;
using System.Text;

namespace Vectors
{
    public class ThreeDimensional
    {
        public struct Point3D
        {
            public int x;
            public int y;
            public int z;
        }

        static Point3D[] GetPoints(int n = 1000)
        {
            Console.WriteLine("\nGenerating three-dimensional points:");
            Point3D[] points = new Point3D[n];

            for (int i = 0; i < n; i++)
            {
                points[i] = new Point3D
                {
                    x = Program.RandomNumber.Next(1, 1001),
                    y = Program.RandomNumber.Next(1, 1001),
                    z = Program.RandomNumber.Next(1, 1001)
                };
                //Console.WriteLine($"\tPoint {i + 1}: \t x = {points[i].x}  \t y = {points[i].y}.");
            }
            return points;
        }

        public static Point3D[] Assign3DPoints()
        {
            Point3D[] newPoints = GetPoints();
            Console.WriteLine($"{newPoints.Length} points generated."); //Points passed back to main.
            return newPoints;
        }

        static double GetDistance3D(Point3D A, Point3D B)
        {
            int width = Math.Abs(A.x) - Math.Abs(B.x);
            int height = Math.Abs(A.y) - Math.Abs(B.y);
            int depth = Math.Abs(A.z) - Math.Abs(B.z);
            return Math.Sqrt(width * width + height * height + depth * depth);
        }

        public static double ShortestDistance3D(Point3D[] points)
        {
            double shortestDistance = 1000; // hard coded 100 due to GetPoints method's max value: 100
            int placeholder1 = 0, placeholder2 = 0; // used for final report to write which point returned the shortest distance

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    double distance = GetDistance3D(points[i], points[j]);

                    //Console.WriteLine($"\tComparing point {i} to point {j}.");

                    if (distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        Console.WriteLine($"\tShortest Distance updated at Point {i} and Point {j}: {shortestDistance}.");
                        placeholder1 = i;
                        placeholder2 = j;
                    }
                }
            }
            Console.WriteLine($"Shortest distance captured at Point {placeholder1} and Point {placeholder2}, Distance: {shortestDistance}.");
            return shortestDistance;
        }
    }
}
