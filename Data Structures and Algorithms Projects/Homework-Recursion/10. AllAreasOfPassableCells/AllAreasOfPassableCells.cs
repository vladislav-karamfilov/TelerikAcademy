using System;
using System.Collections.Generic;

class AllAreasOfPassableCells
{
    static readonly char[,] matrix = new char[,]
    {
        { '-', '-', '-', '*', '-', '-', '-', '-' },
        { '*', '*', '*', '*', '-', '*', '-', '-' },
        { '-', '-', '-', '*', '-', '*', '*', '-' },
        { '-', '*', '*', '-', '*', '-', '-', '*' },
        { '-', '-', '-', '-', '*', '-', '-', '*' },
        { '*', '-', '-', '*', '*', '-', '-', '*' },
        { '*', '*', '-', '*', '-', '-', '-', '*' },
        { '*', '-', '-', '*', '-', '-', '*', '-' },
        { '*', '-', '*', '*', '-', '-', '*', '*' }
    };

    static readonly bool[,] visited =
        new bool[matrix.GetLength(0), matrix.GetLength(1)];

    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding all areas of passable cells in a matrix***");
        Console.Write(decorationLine);

        Console.WriteLine("The matrix is:");
        PrintMatrix();
        Console.WriteLine();

        Console.WriteLine("All areas of passable cells in the matrix are:");
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (!visited[row, col])
                {
                    List<string> currentAreaOfPassableCells = new List<string>();
                    GetAreaOfPassableCells(row, col, currentAreaOfPassableCells, visited);

                    if (currentAreaOfPassableCells.Count != 0)
                    {
                        Console.Write("Area: ");
                        foreach (string cell in currentAreaOfPassableCells)
                        {
                            Console.Write(cell);
                        }

                        Console.WriteLine();
                    }
                }
            }
        }
    }

    static void GetAreaOfPassableCells(int row, int col, List<string> currentAreaOfPassableCells, bool[,] visited)
    {
        if (!CellIsInRange(row, col))
        {
            return;
        }

        if (visited[row, col])
        {
            return;
        }

        if (matrix[row, col] != '-')
        {
            return;
        }

        visited[row, col] = true;
        currentAreaOfPassableCells.Add(string.Format("({0}, {1})", row, col));

        GetAreaOfPassableCells(row, col - 1, currentAreaOfPassableCells, visited); // Left cell
        GetAreaOfPassableCells(row - 1, col, currentAreaOfPassableCells, visited); // Up cell
        GetAreaOfPassableCells(row, col + 1, currentAreaOfPassableCells, visited); // Right cell
        GetAreaOfPassableCells(row + 1, col, currentAreaOfPassableCells, visited); // Down cell
    }

    static bool CellIsInRange(int row, int col)
    {
        if (row < 0 || row >= matrix.GetLength(0))
        {
            return false;
        }

        if (col < 0 || col >= matrix.GetLength(1))
        {
            return false;
        }

        return true;
    }

    static void PrintMatrix()
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0} ", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}
