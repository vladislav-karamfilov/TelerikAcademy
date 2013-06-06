using System;

class Guitar
{
    static void Main()
    {
        char[] separators = { ' ', ',' };
        string[] intervalsInput = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
        int levelChanges = intervalsInput.Length;
        int[] intervals = new int[levelChanges];
        for (int index = 0; index < levelChanges; index++)
        {
            intervals[index] = int.Parse(intervalsInput[index]);
        }
        int baseLevel = int.Parse(Console.ReadLine());
        int maxLevel = int.Parse(Console.ReadLine());
        int[,] posibleLevels = new int[levelChanges + 1, maxLevel + 1];
        // Mark base level
        posibleLevels[0, baseLevel] = 1;
        FindAllVolumes(posibleLevels, intervals);
        int maxVolume = FindMaxVolume(posibleLevels);
        Console.WriteLine(maxVolume);
    }

    static int FindMaxVolume(int[,] posibleLevels)
    {
        for (int col = posibleLevels.GetLength(1) - 1; col >= 0; col--)
        {
            if (posibleLevels[posibleLevels.GetLength(0) - 1, col] == 1)
            {
                return col;
            }
        }
        return -1; // Every level exceeds the max level
    }

    static void FindAllVolumes(int[,] posibleLevels, int[] intervals)
    {
        for (int row = 1; row < posibleLevels.GetLength(0); row++)
        {
            for (int col = posibleLevels.GetLength(1) - 1; col >= 0; col--)
            {
                if (posibleLevels[row - 1, col] == 1)
                {
                    if (col - intervals[row - 1] >= 0)
                    {
                        posibleLevels[row, col - intervals[row - 1]] = 1;
                    }
                    if (col + intervals[row - 1] < posibleLevels.GetLength(1))
                    {
                        posibleLevels[row, col + intervals[row - 1]] = 1;
                    }
                }
            }
        }
    }
}
