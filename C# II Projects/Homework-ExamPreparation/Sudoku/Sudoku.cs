using System;

class Sudoku
{
    static void Main()
    {
        char[,] sudokuGrid = FillInitialSudokuGrid();
        SolveSudoku(sudokuGrid);
    }

    static void SolveSudoku(char[,] sudokuGrid)
    {
        bool solvedSudoku = true;
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (sudokuGrid[row, col] == '-')
                {
                    for (int choice = 1; choice < 10; choice++)
                    {
                        char digit = (char)('0' + choice);
                        sudokuGrid[row, col] = digit;
                        if (CheckPosibility(sudokuGrid, row, col, digit))
                        {
                            SolveSudoku(sudokuGrid);
                        }
                    }
                    sudokuGrid[row, col] = '-';
                    return;
                }
            }
        }
        if (solvedSudoku)
        {
            PrintSudokuGrid(sudokuGrid);
        }
    }

    static bool CheckPosibility(char[,] sudokuGrid, int row, int col, char digit)
    {
        // Check horizontally
        for (int i = 0; i < 9; i++)
        {
            if (i != row)
            {
                if (sudokuGrid[i, col] == digit)
                {
                    return false;
                }
            }
        }
        // Check vertically
        for (int j = 0; j < 9; j++)
        {
            if (j != col)
            {
                if (sudokuGrid[row, j] == digit)
                {
                    return false;
                }
            }
        }
        // Check box
        int maxRow = FindCurrentMaxDimension(row);
        int maxCol = FindCurrentMaxDimension(col);
        for (int currentRow = maxRow - 3; currentRow < maxRow; currentRow++)
        {
            for (int currentCol = maxCol - 3; currentCol < maxCol; currentCol++)
            {
                if (row != currentRow || col != currentCol)
                {
                    if (digit == sudokuGrid[currentRow, currentCol])
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    static int FindCurrentMaxDimension(int dimension)
    {
        if (dimension < 3)
        {
            return 3;
        }
        else if (dimension < 6)
        {
            return 6;
        }
        else
        {
            return 9;
        }
    }

    static char[,] FillInitialSudokuGrid()
    {
        char[,] sudokuGrid = new char[9, 9];
        for (int row = 0; row < 9; row++)
        {
            string currentRow = Console.ReadLine();
            for (int col = 0; col < 9; col++)
            {
                sudokuGrid[row, col] = currentRow[col];
            }
        }
        return sudokuGrid;
    }

    static void PrintSudokuGrid(char[,] sudokuGrid)
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                Console.Write(sudokuGrid[row, col]);
            }
            Console.WriteLine();
        }
    }
}
