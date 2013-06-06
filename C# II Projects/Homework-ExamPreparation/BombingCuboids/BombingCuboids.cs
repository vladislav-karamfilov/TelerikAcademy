using System;

class BombingCuboids
{
    static char[] separator = new char[] { ' ' };
    static int[] lettersHit = new int[91];
    static int totalHits = 0;
    const char EmptyCube = ' ';

    static void Main()
    {
        int width, height, depth;
        string[] dimensions = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
        width = int.Parse(dimensions[0]);
        height = int.Parse(dimensions[1]);
        depth = int.Parse(dimensions[2]);
        char[, ,] cuboid = FillCuboid(width, height, depth);
        int bombsCount = int.Parse(Console.ReadLine());
        for (int bomb = 0; bomb < bombsCount; bomb++)
        {
            string[] bombValues = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int bombWidth = int.Parse(bombValues[0]);
            int bombHeight = int.Parse(bombValues[1]);
            int bombDepth = int.Parse(bombValues[2]);
            int bombPower = int.Parse(bombValues[3]);
            DetonateBomb(cuboid, bombWidth, bombHeight, bombDepth, bombPower);
            FallDown(cuboid);
        }
        PrintResult();
    }

    static void FallDown(char[, ,] cuboid)
    {
        for (int pillarWidth = 0; pillarWidth < cuboid.GetLength(0); pillarWidth++)
        {
            for (int pillarDepth = 0; pillarDepth < cuboid.GetLength(2); pillarDepth++)
            {
                FallDownPillar(pillarWidth, pillarDepth, cuboid);
            }
        }
    }

    static void FallDownPillar(int pillarWidth, int pillarDepth, char[, ,] cuboid)
    {
        int pillarHeight = cuboid.GetLength(1);
        int bottom = 0;
        for (int currentHeight = 0; currentHeight < pillarHeight; currentHeight++)
        {
            if (cuboid[pillarWidth, currentHeight, pillarDepth] != EmptyCube)
            {
                if (bottom != currentHeight)
                {
                    cuboid[pillarWidth, bottom, pillarDepth] = cuboid[pillarWidth, currentHeight, pillarDepth];
                    cuboid[pillarWidth, currentHeight, pillarDepth] = EmptyCube;
                }
                bottom++;
            }
        }
    }

    static void DetonateBomb(char[, ,] cuboid, int bombWidth, int bombHeight, int bombDepth, int bombPower)
    {
        for (int currentWidth = 0; currentWidth < cuboid.GetLength(0); currentWidth++)
        {
            for (int currentHeight = 0; currentHeight < cuboid.GetLength(1); currentHeight++)
            {
                for (int currentDepth = 0; currentDepth < cuboid.GetLength(2); currentDepth++)
                {
                    if (cuboid[currentWidth, currentHeight, currentDepth] != EmptyCube)
                    {
                        int distanceSquared = GetDistanceSquared(currentWidth, currentHeight, currentDepth, bombWidth, bombHeight, bombDepth);
                        int powerSquared = bombPower * bombPower;
                        if (distanceSquared <= powerSquared)
                        {
                            char currentLetter = cuboid[currentWidth, currentHeight, currentDepth];
                            lettersHit[currentLetter]++;
                            totalHits++;
                            cuboid[currentWidth, currentHeight, currentDepth] = EmptyCube;
                        }
                    }
                }
            }
        }
    }

    static int GetDistanceSquared(int currentWidth, int currentHeight, int currentDepth, int bombWidth, int bombHeight, int bombDepth)
    {
        return (currentWidth - bombWidth) * (currentWidth - bombWidth) + (currentHeight - bombHeight) * (currentHeight - bombHeight) +
            (currentDepth - bombDepth) * (currentDepth - bombDepth);
    }

    static void PrintResult()
    {
        Console.WriteLine(totalHits);
        for (int i = 'A'; i < lettersHit.Length; i++)
        {
            if (lettersHit[i] != 0)
            {
                Console.WriteLine("{0} {1}", (char)i, lettersHit[i]);
            }
        }
    }

    static char[, ,] FillCuboid(int width, int height, int depth)
    {
        char[, ,] result = new char[width, height, depth];
        for (int currentHeigth = 0; currentHeigth < height; currentHeigth++)
        {
            string[] plateRows = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
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