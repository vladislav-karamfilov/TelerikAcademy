using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Just3DPoint.Data
{
    public static class PathStorage
    {
        public static void SavePathsToFile(string fileName, List<Path> paths)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.Unicode))
            {
                foreach (Path path in paths)
                {
                    writer.WriteLine(path.ToString());
                }
            }
        }
        public static List<Path> LoadPathsFromFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName, Encoding.Unicode))
            {
                List<Path> paths = new List<Path>();
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    Path newPath = GetCurrentPath(currentLine);
                    paths.Add(newPath);
                    currentLine = reader.ReadLine();
                }                
                return paths;
            }
        }

        private static Path GetCurrentPath(string currentLine)
        {
            string[] pointsCoords = currentLine.Split(new char[] { ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int allCoordsCount = pointsCoords.Length;
            Path newPath = new Path();
            for (int coord = 0; coord < allCoordsCount; coord += 3)
            {
                double currentXCoord = double.Parse(pointsCoords[coord]);
                double currentYCoord = double.Parse(pointsCoords[coord + 1]);
                double currentZCoord = double.Parse(pointsCoords[coord + 2]);
                newPath.AddPoint(new Point3D(currentXCoord, currentYCoord, currentZCoord));
            }
            return newPath;
        }
    }
}
