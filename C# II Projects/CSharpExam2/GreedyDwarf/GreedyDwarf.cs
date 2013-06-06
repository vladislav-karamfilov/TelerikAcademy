using System;

class GreedyDwarf
{
    static long maxCoins = long.MinValue;
    static bool[] visited;

    static void Main()
    {
        char[] separators = { ' ', ',' };
        string[] inputValley = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
        int valleyLength = inputValley.Length;
        int[] valley = new int[valleyLength];
        for (int index = 0; index < valleyLength; index++)
        {
            valley[index] = int.Parse(inputValley[index]);
        }
        //foreach (int item in valley)
        //{
        //    Console.WriteLine(item);
        //}
        int m = int.Parse(Console.ReadLine());
        int[][] patterns = new int[m][];
        for (int i = 0; i < m; i++)
        {
            string[] currentPatterns = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            patterns[i] = new int[currentPatterns.Length];
            for (int j = 0; j < currentPatterns.Length; j++)
            {
                patterns[i][j] = int.Parse(currentPatterns[j]);
            }
        }
        //for (int i = 0; i < m; i++)
        //{
        //    Console.WriteLine("new");
        //    for (int j = 0; j < patterns[i].Length; j++)
        //    {
        //        Console.WriteLine(patterns[i][j]);
        //    }
        //}
        FindMaxCoins(valley, patterns);
        Console.WriteLine(maxCoins);
    }

    static void FindMaxCoins(int[] valley, int[][] patterns)
    {
        for (int i = 0; i < patterns.Length; i++)
        {
            long currentCoins = valley[0];
            int currentIndexInValley = 0;
            visited = new bool[valley.Length];
            visited[0] = true;
            for (int j = 0; j < patterns[i].Length; j++)
            {
                if (ValidIndex(currentIndexInValley + patterns[i][j]))
                {
                    visited[currentIndexInValley + patterns[i][j]] = true;
                    currentCoins += valley[currentIndexInValley + patterns[i][j]];
                    currentIndexInValley += patterns[i][j];
                }
                else
                {
                    break;
                }
                if (j == patterns[i].Length - 1)
                {
                    j = -1;
                }
            }
            if (currentCoins > maxCoins)
	        {
                maxCoins = currentCoins;
	        }
        }
    }

    static bool ValidIndex(int index)
    {
        if (index < 0)
        {
            return false;
        }
        if (index >= visited.Length)
        {
            return false;
        }
        if (visited[index])
        {
            return false;
        }
        return true;
    }
}
