using System;

class PathExistanceBetweenTwoCells
{
    static int startCellRow = 0;
    static int startCellCol = 2;
    static int endCellRow = 20;
    static int endCellCol = 17;
    static char[,] matrix = {
                        { '-', '-', '-', '*', '-', '-', '-', '-', '-', '*', '-', '-', '-', '-', '*', '-', '-', '-' },
                        { '*', '*', '-', '*', '-', '*', '-', '-', '-', '*', '-', '-', '-', '-', '-', '-', '*', '-' },
                        { '-', '-', '-', '-', '-', '*', '-', '-', '-', '-', '-', '*', '-', '-', '-', '-', '*', '-' },
                        { '-', '*', '*', '-', '*', '-', '*', '-', '-', '-', '-', '-', '-', '-', '-', '-', '*', '-' },
                        { '-', '-', '-', '-', '-', '*', '-', '-', '-', '*', '-', '-', '-', '*', '-', '-', '*', '-' },
                        { '*', '-', '-', '*', '-', '-', '-', '-', '-', '-', '-', '*', '-', '-', '-', '-', '*', '-' },
                        { '*', '*', '-', '*', '-', '-', '-', '-', '*', '*', '-', '-', '-', '-', '-', '-', '*', '-' },
                        { '*', '-', '-', '*', '-', '-', '*', '-', '-', '-', '-', '-', '-', '*', '-', '-', '*', '-' },
                        { '*', '-', '*', '*', '-', '-', '-', '-', '-', '*', '-', '-', '-', '-', '-', '-', '*', '-' },
                        { '-', '-', '-', '-', '*', '-', '-', '-', '-', '-', '-', '*', '-', '-', '*', '-', '-', '-' },
                        { '*', '-', '-', '*', '-', '-', '-', '-', '-', '*', '-', '-', '-', '-', '-', '-', '*', '-' },
                        { '-', '-', '-', '*', '-', '-', '-', '-', '-', '-', '*', '-', '-', '*', '-', '*', '*', '*' },
                        { '*', '*', '-', '*', '-', '*', '-', '*', '*', '*', '-', '*', '-', '*', '-', '*', '*', '*' },
                        { '-', '-', '-', '-', '-', '*', '-', '-', '-', '-', '-', '-', '-', '-', '*', '-', '-', '-' },
                        { '-', '*', '*', '-', '*', '-', '*', '-', '-', '-', '-', '-', '-', '*', '-', '*', '*', '*' },
                        { '-', '-', '-', '-', '-', '*', '-', '-', '-', '*', '-', '-', '-', '*', '-', '-', '*', '-' },
                        { '*', '-', '-', '*', '-', '-', '-', '-', '-', '-', '-', '*', '-', '*', '-', '*', '*', '*' },
                        { '*', '-', '-', '*', '-', '-', '-', '*', '*', '*', '-', '-', '-', '-', '*', '-', '-', '-' },
                        { '*', '-', '-', '*', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '*', '-' },
                        { '*', '-', '*', '*', '*', '-', '-', '-', '-', '*', '*', '*', '-', '*', '-', '*', '*', '*' },
                        { '*', '-', '-', '*', '-', '-', '-', '-', '-', '-', '-', '-', '-', '*', '-', '-', '-', '-' }
                            };

    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Checking if a path exist between two cells in a matrix***");
        Console.Write(decorationLine);

        Console.WriteLine("The matrix is:");
        PrintMatrix();
        Console.WriteLine("The start cell is: ({0}, {1}) ", startCellRow, startCellCol);
        Console.WriteLine("The end cell is: ({0}, {1})", endCellRow, endCellCol);
        Console.WriteLine();

        FindPaths(startCellRow, startCellCol);

        Console.WriteLine("There isn't a path between ({0}, {1}) and ({2}, {3})!",
                startCellRow, startCellCol, endCellRow, endCellCol);
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
        
        if (row == endCellRow && col == endCellCol)
        {
            Console.WriteLine("There is a path between ({0}, {1}) and ({2}, {3})!",
                startCellRow, startCellCol, endCellRow, endCellCol);
            Environment.Exit(0);
        }

        FindPaths(row, col - 1); // Go to the left cell
        FindPaths(row - 1, col); // Go to the up cell
        FindPaths(row, col + 1); // Go to the right cell
        FindPaths(row + 1, col); // Go to the down cell

        matrix[row, col] = '-'; // The cell is free to be traversed again
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
