using System;
using System.Collections.Generic;

class HorseMatrix
{
    static char[,] matrix;

    static readonly int[] directionsByRow = { -2, -2, 2, 2, -1, -1, 1, 1 };
    static readonly int[] directionsByCol = { 1, -1, 1, -1, -2, 2, -2, 2 };

    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        matrix = new char[size, size];
        
        int startRow = 0;
        int startCol = 0;
        int endRow = 0;
        int endCol = 0;
        for (int row = 0; row < size; row++)
        {
            string cellsContent = Console.ReadLine();
            int indexInString = 0;
            for (int col = 0; col < size; col++)
            {
                matrix[row, col] = cellsContent[indexInString];
                if (matrix[row, col] == 's')
                {
                    startRow = row;
                    startCol = col;
                }
                else if (matrix[row, col] == 'e')
                {
                    endRow = row;
                    endCol = col;
                }

                indexInString += 2;
            }
        }

        int minDistance = GetMinDistance(startRow, startCol, endRow, endCol);
        if (minDistance != -1)
        {
            Console.WriteLine(minDistance);
        }
        else
        {
            Console.WriteLine("No");
        }
    }

    static int GetMinDistance(int startRow, int startCol, int endRow, int endCol)
    {
        Queue<Tuple<int, int, int>> cells = new Queue<Tuple<int, int, int>>();
        cells.Enqueue(new Tuple<int, int, int>(startRow, startCol, 1));
        while (cells.Count > 0)
        {
            Tuple<int, int, int> currentCell = cells.Dequeue();
            for (int i = 0; i < 8; i++)
            {
                int newRow = currentCell.Item1 + directionsByRow[i];
                int newCol = currentCell.Item2 + directionsByCol[i];
                if (IsInRange(newRow, newCol) && matrix[newRow, newCol] != 'x')
                {
                    if (newRow == endRow && newCol == endCol)
                    {
                        return currentCell.Item3;
                    }

                    cells.Enqueue(new Tuple<int, int, int>(newRow, newCol, currentCell.Item3 + 1));
                    matrix[newRow, newCol] = 'x';
                }
            }
        }

        return -1;
    }

    static bool IsInRange(int row, int col)
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
}