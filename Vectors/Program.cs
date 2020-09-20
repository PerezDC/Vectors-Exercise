using System;
using static Vectors.ThreeDimensional;

namespace Vectors
{
    class Program
    { 
        public static Random RandomNumber = new Random();

        struct Point2D
        {
            public int x;
            public int y;
        }

        static Point2D[] GetPoints(int n = 100)
        {
            Console.WriteLine("\nGenerating two-dimensional points:");
            Point2D[] points = new Point2D[n];

            for (int i = 0; i < n; i++)
            {
                points[i] = new Point2D
                {
                    x = RandomNumber.Next(1, 101),
                    y = RandomNumber.Next(1, 101)
                };
                //Console.WriteLine($"\tPoint {i+1}: \t x = {points[i].x}  \t y = {points[i].y}.");
            }
            return points;
        }

        static Point2D[] Assign2DPoints()
        {
            Point2D[] newPoints = GetPoints();
            Console.WriteLine($"{newPoints.Length} points generated."); //Points passed back to main.
            return newPoints;
        }

        static double GetDistance2D(Point2D A, Point2D B)
        {
            int width = Math.Abs(A.x) - Math.Abs(B.x);
            int height = Math.Abs(A.y) - Math.Abs(B.y);
            return Math.Sqrt(width * width + height * height);
        }

        static double ShortestDistance2D(Point2D[] points)
        {
            double shortestDistance = 100; // hard coded 100 due to GetPoints method's max value: 100
            int placeholder1 = 0, placeholder2 = 0; // used for final report to write which point returned the shortest distance

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    double distance = GetDistance2D(points[i], points[j]);

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

        static void Main(string[] args)
        {
            Console.WriteLine("Programming Exercise 11 | Vector Distance Calculation");
            Console.WriteLine("\nPart One -- Creating two-dimensional data structure containing x and y. Creating a collection of 100 points.");
            Point2D[] generated2DPoints = Assign2DPoints();

            Console.WriteLine("\nPart Two -- Finding the distance between two two-dimensional points.");
            ShortestDistance2D(generated2DPoints);

            Console.WriteLine("\nPart Three -- Creating three-dimensional data structure containing x, y, and z. Creating a collection of 1000 points.");
            Point3D[] generated3DPoints = ThreeDimensional.Assign3DPoints();

            Console.WriteLine("\nPart Four -- Finding the distance between two three-dimensional points.");
            ThreeDimensional.ShortestDistance3D(generated3DPoints);
        }
    }
}
