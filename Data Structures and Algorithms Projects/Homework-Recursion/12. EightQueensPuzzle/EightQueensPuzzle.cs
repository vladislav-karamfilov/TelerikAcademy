using System;
using System.IO;

class EightQueensPuzzle
{
    static readonly string solutionsFilePath = @"../../solutions.txt";
    static int solutionsCount = 0;

    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding all the solutions of the '8 Queens Puzzle'***");
        Console.Write(decorationLine);

        Console.Write("Enter the size of the chessboard: ");
        int size = int.Parse(Console.ReadLine());
        bool[,] chessBoard = new bool[size, size];
        short[,] occupiedCells = new short[size, size];

        SolvePuzzle(chessBoard, occupiedCells, 0);

        Console.WriteLine("All distinct solutions are: {0}", solutionsCount);
        Console.WriteLine(
         "All solutions are in file: '{0}'",
         solutionsFilePath.Substring(solutionsFilePath.LastIndexOf('/') + 1));
    }

    static void SolvePuzzle(bool[,] chessBoard, short[,] occupiedCells, int currentColumn)
    {
        if (currentColumn == chessBoard.GetLength(1))
        {
            solutionsCount++;
            WriteSolutionToFile(chessBoard);
            return;
        }

        for (int row = 0; row < chessBoard.GetLength(0); row++)
        {
            if (occupiedCells[row, currentColumn] == 0)
            {
                chessBoard[row, currentColumn] = true;
                MarkOccupiedCells(occupiedCells, row, currentColumn, 1);

                SolvePuzzle(chessBoard, occupiedCells, currentColumn + 1);

                chessBoard[row, currentColumn] = false;
                MarkOccupiedCells(occupiedCells, row, currentColumn, -1);
            }
        }
    }

    static void MarkOccupiedCells(short[,] occupiedCells, int currentRow, int currentColumn, short value)
    {
        for (int i = 0; i < occupiedCells.GetLength(0); i++)
        {
            occupiedCells[currentRow, i] += value;
            occupiedCells[i, currentColumn] += value;

            if (currentRow + i < occupiedCells.GetLength(0) &&
                currentColumn + i < occupiedCells.GetLength(1))
            {
                occupiedCells[currentRow + i, currentColumn + i] += value;
            }

            if (currentRow - i >= 0 &&
                currentColumn + i < occupiedCells.GetLength(1))
            {
                occupiedCells[currentRow - i, currentColumn + i] += value;
            }
        }
    }

    static void WriteSolutionToFile(bool[,] chessBoard)
    {
        using (StreamWriter writer = new StreamWriter(solutionsFilePath, true))
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    writer.Write("{0} ", chessBoard[row, col] ? 'X' : '-');
                }

                writer.WriteLine();
            }

            writer.WriteLine(Environment.NewLine);
        }
    }
}