using System;

class ThreeDLines
{
    static int longestLine = 1; // At least one cube
    static int[] directionsByWidth = { 1, 0, 1, -1, 0, 0, 0, 1, -1, 1, 1, 1, 1 };
    static int[] directionsByHeight = { 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, -1, 1, -1 };
    static int[] directionsByDepth = { 0, 0, 1, 1, 1, 1, -1, 0, 0, 1, 1, -1, -1 };

    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        int depth = int.Parse(dimensions[2]);
        char[, ,] cuboid = FillCuboid(width, height, depth);
        int countOfLongestLine = FindLongestLineInCuboid(cuboid);
        if (longestLine == 1)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine("{0} {1}", longestLine, countOfLongestLine);
        }
    }

    static int FindLongestLineInCuboid(char[, ,] cuboid)
    {
        int result = 0;
        char currentCubeColor = new char();
        for (int width = 0; width < cuboid.GetLength(0); width++)
        {
            for (int height = 0; height < cuboid.GetLength(1); height++)
            {
                for (int depth = 0; depth < cuboid.GetLength(2); depth++)
                {
                    currentCubeColor = cuboid[width, height, depth];
                    for (int index = 0; index < directionsByWidth.Length; index++)
                    {
                        int currentLineLength = 1;
                        int currentWidth = width;
                        int currentHeight = height;
                        int currentDepth = depth;
                        while (true)
                        {
                            currentWidth += directionsByWidth[index];
                            currentHeight += directionsByHeight[index];
                            currentDepth += directionsByDepth[index];
                            if (!IsValidCube(cuboid, currentWidth, currentHeight, currentDepth))
                            {
                                break;
                            }
                            if (cuboid[currentWidth, currentHeight, currentDepth] == currentCubeColor)
                            {
                                currentLineLength++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (currentLineLength == longestLine)
                        {
                            result++;
                        }
                        else if (currentLineLength > longestLine)
                        {
                            longestLine = currentLineLength;
                            result = 1;
                        }
                    }
                }
            }
        }
        return result;
    }

    static bool IsValidCube(char[, ,] cuboid, int currentWidth, int currentHeight, int currentDepth)
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
