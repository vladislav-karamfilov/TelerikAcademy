using System;
using System.Collections.Generic;

class AllPathsBetweenTwoCellsInAMatrix
{
    static readonly int startCellRow = 0;
    static readonly int startCellCol = 2;
    static readonly int endCellRow = 5;
    static readonly int endCellCol = 6;
    static readonly char[,] matrix = new char[,]
    {
        { '-', '-', '-', '*', '-', '-', '-' },
        { '*', '*', '-', '*', '-', '*', '-' },
        { '-', '-', '-', '-', '-', '*', '-' },
        { '-', '*', '*', '-', '*', '-', '*' },
        { '-', '-', '-', '-', '-', '*', '-' },
        { '*', '-', '-', '*', '-', '-', '-' }
    };
    static readonly List<string> currentPath = new List<string>();
    static bool pathFound = false;

    static void Main(string[] args)
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding all paths between two cells in a matrix***");
        Console.Write(decorationLine);

        Console.WriteLine("The matrix is: ");
        PrintMatrix();
        Console.WriteLine("The start cell is: ({0}, {1}) ", startCellRow, startCellCol);
        Console.WriteLine("The end cell is: ({0}, {1})", endCellRow, endCellCol);
        Console.WriteLine();

        FindPaths(startCellRow, startCellCol);
        if (!pathFound)
        {
            Console.WriteLine("There is no path between ({0}, {1}) and ({2}, {3})!",
                startCellRow, startCellCol, endCellRow, endCellCol);
        }
    }

    static void FindPaths(int row, int col)
    {
        if (!CellIsInRange(row, col))
        {
            return;
        }

        if (matrix[row, col] != '-')
        {
            return;
        }

        matrix[row, col] = 'v';
        currentPath.Add(string.Format("({0}, {1})", row, col));

        if (row == endCellRow && col == endCellCol)
        {
            pathFound = true;
            PrintCurrentPath(currentPath);
            matrix[row, col] = '-';
            return;
        }

        FindPaths(row, col - 1); // Go to the left cell
        FindPaths(row - 1, col); // Go to the up cell
        FindPaths(row, col + 1); // Go to the right cell
        FindPaths(row + 1, col); // Go to the down cell

        matrix[row, col] = '-'; // The cell is free to be traversed again
        currentPath.RemoveAt(currentPath.Count - 1);
    }

    static void PrintCurrentPath(List<string> currentPath)
    {
        Console.Write("Path: ");
        for (int i = 0; i < currentPath.Count; i++)
        {
            Console.Write(currentPath[i]);
        }

        Console.WriteLine();
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