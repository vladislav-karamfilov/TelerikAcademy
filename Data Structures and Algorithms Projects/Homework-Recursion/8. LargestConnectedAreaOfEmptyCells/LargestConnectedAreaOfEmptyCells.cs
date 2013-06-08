using System;
using System.Collections.Generic;

class LargestConnectedAreaOfEmptyCells
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the largest connected area of empty cells in a matrix***");
        Console.Write(decorationLine);

        char[,] matrix = {
                            { '-', '-', '-', '*', '-', '-', '-', '-' },
                            { '*', '*', '*', '*', '-', '*', '-', '-' },
                            { '-', '-', '-', '*', '-', '*', '*', '-' },
                            { '-', '*', '*', '-', '*', '-', '-', '*' },
                            { '-', '-', '-', '-', '*', '-', '-', '*' },
                            { '*', '-', '-', '*', '*', '-', '-', '*' },
                            { '*', '*', '-', '*', '-', '-', '-', '*' },
                            { '*', '-', '-', '*', '-', '-', '*', '-' },
                            { '*', '-', '*', '*', '-', '-', '*', '-' }
                         };
        Console.WriteLine("The matrix is: ");
        PrintMatrix(matrix);
        Console.WriteLine();

        bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
        List<string> largestAreaOfEmptyCells = new List<string>();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (!visited[row, col])
                {
                    List<string> currentAreaOfEmptyCells = new List<string>();
                    GetAreaOfEmptyCells(matrix, row, col, currentAreaOfEmptyCells, visited);
                    if (currentAreaOfEmptyCells.Count > largestAreaOfEmptyCells.Count)
                    {
                        largestAreaOfEmptyCells = currentAreaOfEmptyCells;
                    }
                }
            }
        }

        Console.WriteLine("The largest connected area of empty cells in the matrix is: ");
        PrintLargestAreaOfEmptyCells(largestAreaOfEmptyCells);
    }

    private static void GetAreaOfEmptyCells(char[,] matrix, int row, int col, List<string> currentAreaOfEmptyCells, bool[,] visited)
    {
        if (!CellIsInRange(matrix, row, col))
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
        currentAreaOfEmptyCells.Add(string.Format("({0}, {1})", row, col));

        GetAreaOfEmptyCells(matrix, row, col - 1, currentAreaOfEmptyCells, visited); // Left cell
        GetAreaOfEmptyCells(matrix, row - 1, col, currentAreaOfEmptyCells, visited); // Up cell
        GetAreaOfEmptyCells(matrix, row, col + 1, currentAreaOfEmptyCells, visited); // Right cell
        GetAreaOfEmptyCells(matrix, row + 1, col, currentAreaOfEmptyCells, visited); // Down cell
    }

    static bool CellIsInRange(char[,] matrix, int row, int col)
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

    static void PrintMatrix(char[,] matrix)
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

    static void PrintLargestAreaOfEmptyCells(List<string> largestAreaOfEmptyCells)
    {
        for (int i = 0; i < largestAreaOfEmptyCells.Count; i++)
        {
            Console.Write(largestAreaOfEmptyCells[i]);
        }

        Console.WriteLine();
    }
}
