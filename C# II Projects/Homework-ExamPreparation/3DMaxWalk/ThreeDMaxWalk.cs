using System;

class ThreeDMaxWalk
{
    static int maxWalkSum = 0;
    static bool[, ,] visitedCubes;

    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        int depth = int.Parse(dimensions[2]);
        short[, ,] cuboid = FillCuboid(width, height, depth);
        visitedCubes = new bool[width, height, depth];
        WalkTheCuboid(cuboid, width / 2, height / 2, depth / 2);
        Console.WriteLine(maxWalkSum);
    }

    static void WalkTheCuboid(short[, ,] cuboid, int width, int height, int depth)
    {
        maxWalkSum = cuboid[width, height, depth];
        cuboid[width, height, depth] = short.MinValue;
        int maxNeighbourWidth = 0;
        int maxNeighbourHeight = 0;
        int maxNeighbourDepth = 0;
        while (true)
        {
            short maxNeighbour = short.MinValue;
            int countMaxNeighbours = 0;
            int i = 1;
            while (IsValidCube(cuboid, width - i, height, depth))
            {
                if (maxNeighbour < cuboid[width - i, height, depth])
                {
                    maxNeighbour = cuboid[width - i, height, depth];
                    maxNeighbourWidth = width - i;
                    maxNeighbourHeight = height;
                    maxNeighbourDepth = depth;
                    countMaxNeighbours = 1;
                }
                i++;
            }
            i = 1;
            while (IsValidCube(cuboid, width + i, height, depth))
            {
                if (maxNeighbour == cuboid[width + i, height, depth])
                {
                    countMaxNeighbours++;
                }
                if (maxNeighbour < cuboid[width + i, height, depth])
                {
                    maxNeighbour = cuboid[width + i, height, depth];
                    maxNeighbourWidth = width + i;
                    maxNeighbourHeight = height;
                    maxNeighbourDepth = depth;
                    countMaxNeighbours = 1;
                }
                i++;
            }
            i = 1;
            while (IsValidCube(cuboid, width, height - i, depth))
            {
                if (maxNeighbour == cuboid[width, height - i, depth])
                {
                    countMaxNeighbours++;
                }
                if (maxNeighbour < cuboid[width, height - i, depth])
                {
                    maxNeighbour = cuboid[width, height - i, depth];
                    maxNeighbourWidth = width;
                    maxNeighbourHeight = height - i;
                    maxNeighbourDepth = depth;
                    countMaxNeighbours = 1;
                }
                i++;
            }
            i = 1;
            while (IsValidCube(cuboid, width, height + i, depth))
            {
                if (maxNeighbour == cuboid[width, height + i, depth])
                {
                    countMaxNeighbours++;
                }
                if (maxNeighbour < cuboid[width, height + i, depth])
                {
                    maxNeighbour = cuboid[width, height + i, depth];
                    maxNeighbourWidth = width;
                    maxNeighbourHeight = height + i;
                    maxNeighbourDepth = depth;
                    countMaxNeighbours = 1;
                }
                i++;
            }
            i = 1;
            while (IsValidCube(cuboid, width, height, depth - i))
            {
                if (maxNeighbour == cuboid[width, height, depth - i])
                {
                    countMaxNeighbours++;
                }
                if (maxNeighbour < cuboid[width, height, depth - i])
                {
                    maxNeighbour = cuboid[width, height, depth - i];
                    maxNeighbourWidth = width;
                    maxNeighbourHeight = height;
                    maxNeighbourDepth = depth - i;
                    countMaxNeighbours = 1;
                }
                i++;
            }
            i = 1;
            while (IsValidCube(cuboid, width, height, depth + i))
            {
                if (maxNeighbour == cuboid[width, height, depth + i])
                {
                    countMaxNeighbours++;
                }
                if (maxNeighbour < cuboid[width, height, depth + i])
                {
                    maxNeighbour = cuboid[width, height, depth + i];
                    maxNeighbourWidth = width;
                    maxNeighbourHeight = height;
                    maxNeighbourDepth = depth + i;
                    countMaxNeighbours = 1;
                }
                i++;
            }
            if (visitedCubes[maxNeighbourWidth, maxNeighbourHeight, maxNeighbourDepth] ||
                countMaxNeighbours > 1 || maxNeighbour == short.MinValue)
            {
                break;
            }
            maxWalkSum += maxNeighbour;
            visitedCubes[maxNeighbourWidth, maxNeighbourHeight, maxNeighbourDepth] = true;
            width = maxNeighbourWidth;
            height = maxNeighbourHeight;
            depth = maxNeighbourDepth;
        }
    }

    static bool IsValidCube(short[, ,] cuboid, int currentWidth, int currentHeight, int currentDepth)
    {
        if (currentWidth < 0 || currentWidth >= cuboid.GetLength(0))
        {
            return false;
        }
        if (currentHeight < 0 || currentHeight >= cuboid.GetLength(1))
        {
            return false;
        }
        if (currentDepth < 0 || currentDepth >= cuboid.GetLength(2))
        {
            return false;
        }
        return true;
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
                }
            }
        }
        return cuboid;
    }
}
