using System;

class ForestRoad
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int pathPosition = 0;
        for (int row = 0; row < 2 * n - 1; row++)
        {
            if (row < n) // Geeko's path is top left to middle right
            {
                for (int symbolPosition = 0; symbolPosition < n; symbolPosition++)
                {
                    if (symbolPosition == pathPosition)
                    {
                        Console.Write("*"); // Print Geeko's path
                    }
                    else
                    {
                        Console.Write("."); // Print a tree
                    }
                }
                pathPosition++; // Move the path one step forward
                if (pathPosition == n)
                {
                    pathPosition -= 2; // Returning the position to n - 1
                }
            }
            else // Geeko's path is middle right to bottom left
            {
                for (int symbolPosition = 0; symbolPosition < n; symbolPosition++)
                {
                    if (symbolPosition == pathPosition)
                    {
                        Console.Write("*"); // Print Geeko's path
                    }
                    else
                    {
                        Console.Write("."); // Print a tree
                    }
                }
                pathPosition--; // Move the path one step backward
            }
            Console.WriteLine();
        }
    }
}
