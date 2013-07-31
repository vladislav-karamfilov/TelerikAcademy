using System;
using System.Collections.Generic;

class ThreeDLabyrinth
{
    static char[, ,] labyrinth;
    static int[] directionsX = { 0, 0, -1, 1 };
    static int[] directionsY = { -1, 1, 0, 0 };

    static void Main()
    {
        string[] startPosition = Console.ReadLine().Split(' ');
        int startZ = int.Parse(startPosition[0]);
        int startX = int.Parse(startPosition[1]);
        int startY = int.Parse(startPosition[2]);

        string[] dimensions = Console.ReadLine().Split(' ');
        int z = int.Parse(dimensions[0]);
        int x = int.Parse(dimensions[1]);
        int y = int.Parse(dimensions[2]);

        labyrinth = new char[z, x, y];
        for (int i = 0; i < z; i++)
        {
            for (int j = 0; j < x; j++)
            {
                string symbols = Console.ReadLine();
                for (int k = 0; k < y; k++)
                {
                    labyrinth[i, j, k] = symbols[k];
                }
            }
        }

        Console.WriteLine(GetMinMoves(startZ, startX, startY));
    }

    static int GetMinMoves(int startZ, int startX, int startY)
    {
        Queue<Tuple<int, int, int, int>> cells =
            new Queue<Tuple<int, int, int, int>>();
        cells.Enqueue(new Tuple<int, int, int, int>(startZ, startX, startY, 0));
        while (cells.Count > 0)
        {
            Tuple<int, int, int, int> current = cells.Dequeue();

            if (labyrinth[current.Item1, current.Item2, current.Item3] == 'D')
            {
                if (current.Item1 - 1 < 0)
                {
                    return current.Item4 + 1;
                }

                if (IsValidMove(current.Item1 - 1, current.Item2, current.Item3))
                {
                    cells.Enqueue(new Tuple<int, int, int, int>(
                        current.Item1 - 1, current.Item2, current.Item3, current.Item4 + 1));
                }
            }

            if (labyrinth[current.Item1, current.Item2, current.Item3] == 'U')
            {
                if (current.Item1 + 1 >= labyrinth.GetLength(0))
                {
                    return current.Item4 + 1;
                }

                if (IsValidMove(current.Item1 + 1, current.Item2, current.Item3))
                {
                    cells.Enqueue(new Tuple<int, int, int, int>(
                        current.Item1 + 1, current.Item2, current.Item3, current.Item4 + 1));
                }
            }

            for (int i = 0; i < 4; i++)
            {
                int newX = current.Item2 + directionsX[i];
                int newY = current.Item3 + directionsY[i];
                if (IsValidMove(current.Item1, newX, newY))
                {
                    cells.Enqueue(new Tuple<int, int, int, int>(current.Item1, newX, newY, current.Item4 + 1));
                    labyrinth[current.Item1, current.Item2, current.Item3] = '#';
                }
            }
        }

        return -1;
    }

    static bool IsValidMove(int z, int x, int y)
    {
        if (z < 0 || z >= labyrinth.GetLength(0))
        {
            return false;
        }

        if (x < 0 || x >= labyrinth.GetLength(1))
        {
            return false;
        }

        if (y < 0 || y >= labyrinth.GetLength(2))
        {
            return false;
        }

        if (labyrinth[z, x, y] == '#')
        {
            return false;
        }

        return true;
    }
}