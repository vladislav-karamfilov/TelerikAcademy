using System;

class ThreeDSlices
{
    static int sumOfAllCubes = 0;

    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        int depth = int.Parse(dimensions[2]);
        short[, ,] cuboid = FillCuboid(width, height, depth);
        int countEqualSubcuboids = FindEqualSubcuboids(cuboid);
        Console.WriteLine(countEqualSubcuboids);
    }

    static int FindEqualSubcuboids(short[, ,] cuboid)
    {
        int result = 0;
        // Slicing the cuboid into subcuboids by width dimension
        int currentSumOfCubes = 0;
        for (int currentWidth = 0; currentWidth < cuboid.GetLength(0) - 1; currentWidth++)
        {
            for (int currentHeight = 0; currentHeight < cuboid.GetLength(1); currentHeight++)
            {
                for (int currentDepth = 0; currentDepth < cuboid.GetLength(2); currentDepth++)
                {
                    currentSumOfCubes += cuboid[currentWidth, currentHeight, currentDepth];
                }
            }
            if (currentSumOfCubes == sumOfAllCubes / 2)
            {
                result++;
            }
        }
        // Slicing the cuboid into subcuboids by height dimension
        currentSumOfCubes = 0;
        for (int currentHeight = 0; currentHeight < cuboid.GetLength(1) - 1; currentHeight++)
        {
            for (int currentWidth = 0; currentWidth < cuboid.GetLength(0); currentWidth++)
            {
                for (int currentDepth = 0; currentDepth < cuboid.GetLength(2); currentDepth++)
                {
                    currentSumOfCubes += cuboid[currentWidth, currentHeight, currentDepth];
                }
            }
            if (currentSumOfCubes == sumOfAllCubes / 2)
            {
                result++;
            }
        }
        // Slicing the cuboid into subcuboids by depth dimension
        currentSumOfCubes = 0;
        for (int currentDepth = 0; currentDepth < cuboid.GetLength(2) - 1; currentDepth++)
        {
            for (int currentWidth = 0; currentWidth < cuboid.GetLength(0); currentWidth++)
            {
                for (int currentHeight = 0; currentHeight < cuboid.GetLength(1); currentHeight++)
                {
                    currentSumOfCubes += cuboid[currentWidth, currentHeight, currentDepth];
                }
            }
            if (currentSumOfCubes == sumOfAllCubes / 2)
            {
                result++;
            }
        }
        return result;
    }

    static short[, ,] FillCuboid(int width, int height, int depth)
    {
        short[, ,] cuboid = new short[width, height, depth];
        for (int currentHeight = 0; currentHeight < height; currentHeight++)
        {
            string[] plateRows = Console.ReadLine().Split('|');
            for (int currentDepth = 0; currentDepth < depth; currentDepth++)
            {
                string[] cubeValues = plateRows[currentDepth].Trim().Split(' ');
                for (int currentWidth = 0; currentWidth < width; currentWidth++)
                {
                    cuboid[currentWidth, currentHeight, currentDepth] = short.Parse(cubeValues[currentWidth]);
                    sumOfAllCubes += cuboid[currentWidth, currentHeight, currentDepth];
                }
            }
        }
        return cuboid;
    }
}
