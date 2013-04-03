using System;
using Just3DPoint.Data;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;

namespace Just3DPoint.UI
{
    class Just3DPointUI
    {
        static readonly Random randomGenerator = new Random();

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Finding the distance between two 3D points, generating paths from 3D points,");
            Console.WriteLine("saving and loading paths from a text file***");
            Console.Write(decorationLine);
            // Testing the Point3D class

            // User-defined 3D point
            Point3D point = new Point3D();
            Console.Write("Enter point's X coordinate: ");
            double xCoord = double.Parse(Console.ReadLine().Replace(',', '.'));
            Console.Write("Enter point's Y coordinate: ");
            double yCoord = double.Parse(Console.ReadLine().Replace(',', '.'));
            Console.Write("Enter point's Z coordinate: ");
            double zCoord = double.Parse(Console.ReadLine().Replace(',', '.'));
            point.XCoord = xCoord;
            point.YCoord = yCoord;
            point.ZCoord = zCoord;
            // Random points
            Point3D[] points = new Point3D[10] 
            {
                new Point3D(2.2, 1.2, 11),
                new Point3D(5, 12.2, -11.1),
                new Point3D(-1.2, -21.2, -67.2),
                new Point3D(-2.2, 42.2, 5),
                new Point3D(6, -6, -12.3),
                new Point3D(12.2, 1.2, -17.9),
                new Point3D(15.68, 56.94, 188.36),
                new Point3D(158.215, -1259.295, 6851.86),
                Point3D.CoordSystemStart,
                point
            };

            // Testing the class Two3DPointsDistance
            double distance = Two3DPointsDistance.GetTwoPointsDistance(points[9], points[6]);
            Console.WriteLine("The distance between {0} and {1} is {2}.", points[9], points[6], distance);
            Console.WriteLine();

            // Testing the class Path

            // Constructing a path with given points
            Path path1 = new Path(points[6], points[1], points[8]);
            // Constructing a path with no points and add some
            Path path2 = new Path();
            path2.AddPoint(points[0]);
            path2.AddPoint(points[9]);
            path2.AddPoint(points[5]);
            path2.AddPoint(points[8]);
            // Constructing a path with a fixed number of points
            Path path3 = new Path(10);
            for (int counter = 0; counter < 10; counter++)
            {
                path3.AddPoint(points[randomGenerator.Next(0, 10)]);
            }
            Console.WriteLine("Path1: {0}", path1);
            Console.WriteLine("Path2: {0}", path2);
            path2.RemovePoint(points[8]); // Removing a point
            Console.WriteLine("Path2 after removal of a point: {0}", path2);
            Console.WriteLine("Path3: {0}", path3);
            Console.WriteLine();

            // Testing the class PathStorage

            // Saving the paths to a file
            string fileName = "..\\..\\storage.txt";
            List<Path> allPaths = new List<Path>() { path1, path2, path3 };
            Console.WriteLine("---Saving the paths to the file 'storage.txt' (in project's directory)---");
            PathStorage.SavePathsToFile(fileName, allPaths);
            Console.WriteLine("Saving completed successfully!");
            
            Console.WriteLine();
            allPaths.Clear(); // Clearing the list to test the loading from a file
            
            // Loading paths from a file
            Console.WriteLine("---Loading the paths from the file 'storage.txt' (in project's directory)---");
            allPaths = PathStorage.LoadPathsFromFile(fileName);
            Console.WriteLine("Loading completed successfully!");
            Console.WriteLine("Now printing all the paths:");
            foreach (Path path in allPaths)
            {
                Console.WriteLine("Path: " + path.ToString());
            }
        }
    }
}
