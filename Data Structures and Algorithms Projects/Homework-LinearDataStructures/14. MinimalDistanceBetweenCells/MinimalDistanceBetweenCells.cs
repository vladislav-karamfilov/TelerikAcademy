using System;
using System.Collections.Generic;

class MinimalDistanceBetweenCells
{
    //private static readonly string[,] labyrinth = new string[,]
    //{
    //    { "0", "0", "0", "x", "0", "x" },
    //    { "0", "x", "0", "x", "0", "x" },
    //    { "0", "0", "x", "0", "x", "0" },
    //    { "0", "x", "0", "0", "0", "0" },
    //    { "0", "0", "0", "x", "x", "0" },
    //    { "0", "0", "0", "x", "0", "x" },
    //};

    private static readonly string[,] Labyrinth = new string[,]
    {
        { "0", "0", "x", "0", "0", "x", "0", "x", "0", "x" },
        { "x", "0", "0", "0", "x", "0", "x", "0", "x", "0" },
        { "0", "0", "0", "x", "0", "x", "x", "0", "0", "x" },
        { "0", "x", "0", "0", "0", "x", "x", "x", "0", "0" },
        { "0", "0", "x", "0", "0", "x", "0", "x", "0", "x" },
        { "x", "0", "0", "0", "0", "0", "0", "x", "x", "x" },
        { "0", "0", "x", "0", "0", "x", "0", "x", "0", "0" },
        { "x", "0", "x", "0", "0", "0", "0", "0", "0", "x" },
        { "0", "0", "0", "0", "0", "0", "0", "x", "x", "x" },
        { "0", "0", "x", "0", "0", "x", "0", "x", "0", "x" }
    };

    private static readonly int[,] Directions = new int[,]
    {
        { 0, -1, 0, 1 },
        { -1, 0, 1, 0 }
    };

    public static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.Write("***A labyrinth of empty ('0') and full ('x') cells traversal from start position");
        Console.WriteLine("and filling it with the minimal distance from start position to the other cells");
        Console.WriteLine("and indicating the unreachable cells ('u')***");
        Console.Write(decorationLine);

        Console.WriteLine("The initial labyrinth is:");
        PrintLabyrinthOnConsole();

        Console.WriteLine();

        int startRow = 0;
        int startCol = 0;
        while (true)
        {
            try
            {
                GetInitialPosition(out startRow, out startCol);
                break;
            }
            catch (IndexOutOfRangeException ioore)
            {
                Console.WriteLine(ioore.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input!");
            }
        }

        TraverseLabyrinth(startRow, startCol);

        Console.WriteLine("\nThe result of the traversal of the labyrinth is:");
        PrintLabyrinthOnConsole();
    }

    private static void TraverseLabyrinth(int startRow, int startCol)
    {
        int currentRow = startRow;
        int currentCol = startCol;
        int currentDistance = 1;
        
        Queue<Tuple<int, int, int>> cells = new Queue<Tuple<int, int, int>>();
        cells.Enqueue(new Tuple<int, int, int>(currentRow, currentCol, currentDistance));
        Labyrinth[currentRow, currentCol] = "*";
        
        while (cells.Count > 0)
        {
            Tuple<int, int, int> currentCell = cells.Dequeue();
            currentRow = currentCell.Item1;
            currentCol = currentCell.Item2;
            currentDistance = currentCell.Item3;

            for (int i = 0; i < Directions.GetLength(1); i++)
            {
                int newRow = currentRow + Directions[0, i];
                int newCol = currentCol + Directions[1, i];
                if (IsValidCell(newRow, newCol) && Labyrinth[newRow, newCol] == "0")
                {
                    Labyrinth[newRow, newCol] = currentDistance.ToString();

                    cells.Enqueue(new Tuple<int, int, int>(newRow, newCol, currentDistance + 1));
                }
            }
        }

        MarkUnreachableCells();
    }

    private static void MarkUnreachableCells()
    {
        for (int row = 0; row < Labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < Labyrinth.GetLength(1); col++)
            {
                if (Labyrinth[row, col] == "0")
                {
                    Labyrinth[row, col] = "u";
                }
            }
        }
    }

    private static bool IsValidCell(int row, int col)
    {
        if (row < 0 || row >= Labyrinth.GetLength(0))
        {
            return false;
        }

        if (col < 0 || col >= Labyrinth.GetLength(1))
        {
            return false;
        }

        return true;
    }

    private static void GetInitialPosition(out int row, out int col)
    {

        Console.Write("Enter start position row: ");
        int inputRow = int.Parse(Console.ReadLine());

        Console.Write("Enter start position column: ");
        int inputCol = int.Parse(Console.ReadLine());

        if (inputRow < 0 || inputRow >= Labyrinth.GetLength(0))
        {
            throw new IndexOutOfRangeException("Start row is out of the labyrinth!");
        }

        if (inputCol < 0 || inputCol >= Labyrinth.GetLength(1))
        {
            throw new IndexOutOfRangeException("Start column is out of the labyrinth!");
        }

        row = inputRow;
        col = inputCol;
    }

    private static void PrintLabyrinthOnConsole()
    {
        Console.Write("    | ");
        for (int col = 0; col < Labyrinth.GetLength(0); col++)
        {
            Console.Write("{0, 3} ", col);
        }

        Console.WriteLine("\n{0}", new string('-', Labyrinth.GetLength(0) * 4 + 5));
        for (int row = 0; row < Labyrinth.GetLength(0); row++)
        {
            Console.Write("{0, 3} | ", row);
            for (int col = 0; col < Labyrinth.GetLength(1); col++)
            {
                Console.Write("{0, 3} ", Labyrinth[row, col]);
            }

            Console.WriteLine();
        }
    }
}
