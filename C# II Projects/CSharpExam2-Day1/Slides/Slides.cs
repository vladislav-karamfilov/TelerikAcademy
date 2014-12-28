using System;
// TODO: Improve!!! 85/100
class Slides
{
    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        int depth = int.Parse(dimensions[2]);
        string[, ,] cuboid = FillCuboid(width, height, depth);
        string[] initialPositions = Console.ReadLine().Split(' ');
        int ballW = int.Parse(initialPositions[0]);
        int ballD = int.Parse(initialPositions[1]);
        LetTheBall(cuboid, ballW, ballD);
        //PrintCuboid(width, height, depth, cuboid);
    }

    static void LetTheBall(string[, ,] cuboid, int ballW, int ballD)
    {
        int ballH = 0;
        int newH = ballH;
        int newW = ballW;
        int newD = ballD;
        while (true)
        {
            if (cuboid[ballW, ballH, ballD].StartsWith("E"))
            {
                newH = ballH + 1;
            }
            else if (cuboid[ballW, ballH, ballD].StartsWith("T"))
            {
                string[] newCoords = cuboid[ballW, ballH, ballD].Split(' ');
                newW = int.Parse(newCoords[1]);
                newD = int.Parse(newCoords[2]);
            }
            else if (cuboid[ballW, ballH, ballD].StartsWith("S"))
            {
                string[] directions = cuboid[ballW, ballH, ballD].Split(' ');
                newH = ballH + 1;
                switch (directions[1])
                {
                    case "L":
                        newW--;
                        break;
                    case "R":
                        newW++;
                        break;
                    case "B":
                        newD++;
                        break;
                    case "F":
                        newD--;
                        break;
                    case "FL":
                        newD--;
                        newW--;
                        break;
                    case "FR":
                        newD--;
                        newW++;
                        break;
                    case "BL":
                        newD++;
                        newW--;
                        break;
                    case "BR":
                        newD++;
                        newW++;
                        break;
                }
            }
            else if (cuboid[ballW, ballH, ballD].StartsWith("B"))
            {
                Console.WriteLine("No");
                Console.WriteLine("{0} {1} {2}", ballW, ballH, ballD);
                return;
            }
            if (ballH == cuboid.GetLength(1) - 1)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("{0} {1} {2}", ballW, ballH, ballD);
                return;
            }
            if (!ValidNewCoords(newW, newH, newD, cuboid))
            {
                Console.WriteLine("No");
                Console.WriteLine("{0} {1} {2}", ballW, ballH, ballD);
                return;
            }
            ballW = newW;
            ballH = newH;
            ballD = newD;
        }
    }

    static bool ValidNewCoords(int newW, int newH, int newD, string[, ,] cuboid)
    {
        if (newW < 0 || newW >= cuboid.GetLength(0))
        {
            return false;
        }
        if (newH < 0 || newH >= cuboid.GetLength(1))
        {
            return false;
        }
        if (newD < 0 || newD >= cuboid.GetLength(2))
        {
            return false;
        }
        return true;
    }

    static void PrintCuboid(int width, int height, int depth, string[, ,] cuboid)
    {
        Console.WriteLine();
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                for (int k = 0; k < depth; k++)
                {
                    Console.Write(cuboid[k, i, j] + " || ");
                }
            }
            Console.WriteLine();
        }
    }

    static string[, ,] FillCuboid(int width, int height, int depth)
    {
        string[, ,] cuboid = new string[width, height, depth];
        for (int currentHeight = 0; currentHeight < height; currentHeight++)
        {
            char[] currentSeparator = { '|' };
            string[] plateRows = Console.ReadLine().Split(currentSeparator, StringSplitOptions.RemoveEmptyEntries);
            currentSeparator = new char[] { ')' };
            for (int currentDepth = 0; currentDepth < depth; currentDepth++)
            {
                string[] cubeValues = plateRows[currentDepth].Split(currentSeparator, StringSplitOptions.RemoveEmptyEntries);
                for (int currentWidth = 0; currentWidth < width; currentWidth++)
                {
                    cuboid[currentWidth, currentHeight, currentDepth] = cubeValues[currentWidth].TrimStart('(', ' ');
                }
            }
        }
        return cuboid;
    }
}