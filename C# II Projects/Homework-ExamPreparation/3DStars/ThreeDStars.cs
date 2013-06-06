using System;
using System.Collections.Generic;

class ThreeDStars
{
    static SortedDictionary<char, int> starKinds = new SortedDictionary<char, int>();    

    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        int depth = int.Parse(dimensions[2]);
        char[, ,] cuboid = FillCuboid(width, height, depth);
        int starsInCuboid = CountStarsInCuboid(cuboid);
        Console.WriteLine(starsInCuboid);
        foreach (KeyValuePair<char, int> star in starKinds)
        {
            Console.WriteLine("{0} {1}", star.Key, star.Value);
        }
    }

    static int CountStarsInCuboid(char[, ,] cuboid)
    {
        int stars = 0;
        char currentCubeColor = new char();
        for (int currentWidth = 1; currentWidth < cuboid.GetLength(0) - 1; currentWidth++)
        {
            for (int currentHeight = 1; currentHeight < cuboid.GetLength(1) - 1; currentHeight++)
            {
                for (int currentDepth = 1; currentDepth < cuboid.GetLength(2) - 1; currentDepth++)
                {
                    currentCubeColor = cuboid[currentWidth, currentHeight, currentDepth];
                    if (currentCubeColor == cuboid[currentWidth - 1, currentHeight, currentDepth] &&
                        currentCubeColor == cuboid[currentWidth + 1, currentHeight, currentDepth] &&
                        currentCubeColor == cuboid[currentWidth, currentHeight - 1, currentDepth] &&
                        currentCubeColor == cuboid[currentWidth, currentHeight + 1, currentDepth] &&
                        currentCubeColor == cuboid[currentWidth, currentHeight, currentDepth - 1] &&
                        currentCubeColor == cuboid[currentWidth, currentHeight, currentDepth + 1])
                    {
                        stars++;
                        if (!starKinds.ContainsKey(cuboid[currentWidth, currentHeight, currentDepth]))
                        {
                            starKinds.Add(cuboid[currentWidth, currentHeight, currentDepth], 1);
                        }
                        else
                        {
                            starKinds[cuboid[currentWidth, currentHeight, currentDepth]]++;
                        }
                    }
                }
            }
        }
        return stars;
    }

    static char[, ,] FillCuboid(int width, int height, int depth)
    {
        char[, ,] result = new char[width, height, depth];
        for (int currentHeigth = 0; currentHeigth < height; currentHeigth++)
        {
            string[] plateRows = Console.ReadLine().Split(' ');
            for (int currentDepth = 0; currentDepth < depth; currentDepth++)
            {
                string currentPlateRow = plateRows[currentDepth];
                for (int currentWidth = 0; currentWidth < width; currentWidth++)
                {
                    result[currentWidth, currentHeigth, currentDepth] = currentPlateRow[currentWidth];
                }
            }
        }
        return result;
    }
}
