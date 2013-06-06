namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine("---Examples of method GetFileExtension from static class FileUtils---");
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));
            Console.WriteLine();

            Console.WriteLine("---Examples of method GetFileNameWithoutExtension from static class FileUtils---");
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));
            Console.WriteLine();

            Console.WriteLine("---Examples of methods CalculateDistance2D and CalculateDistance3D from static class GeometryUtils---");
            Console.WriteLine("Distance between points (1, -2) and (3, 4) in the 2D space = {0:f2}",
                GeometryUtils.CalculateDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance between points (5, 2), (-1, 3) and (-6, 4) in the 3D space = {0:f2}",
                GeometryUtils.CalculateDistance3D(5, 2, -1, 3, -6, 4));
            Console.WriteLine();

            Console.WriteLine("---Examples of the methods in the class RectangularCuboid---");
            RectangularCuboid rectangularCuboid = new RectangularCuboid(3, 4, 5);
            Console.WriteLine("Width = {0}\nHeight = {1}\nDepth = {2}", 
                rectangularCuboid.Width, rectangularCuboid.Height, rectangularCuboid.Depth);
            Console.WriteLine("Volume = {0:f2}", rectangularCuboid.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", rectangularCuboid.CalculateDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", rectangularCuboid.CalculateDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", rectangularCuboid.CalculateDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", rectangularCuboid.CalculateDiagonalYZ());
        }
    }
}
