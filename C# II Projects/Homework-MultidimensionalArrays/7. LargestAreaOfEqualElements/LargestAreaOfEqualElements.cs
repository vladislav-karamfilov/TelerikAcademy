using System;

class LargestAreaOfEqualElements
{
    static bool[,] visitedCells;
    static int[,] matrix;
    static int currentAreaSize;

    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the size of the largest area of equal neighbour elements in a \nrectangular matrix of integers***");
        Console.Write(decorationLine);
        Console.Write("Enter how many rows the matrix has: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter how many columns the matrix has: ");
        int columns = int.Parse(Console.ReadLine());
        matrix = new int[rows, columns];
        visitedCells = new bool[5, 6];
        FillMatrix();
        // Traversing the matrix
        int largestAreaSize = 0;
        int element = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                currentAreaSize = 0;
                CalculateArea(row, col);
                if (currentAreaSize > largestAreaSize)
                {
                    largestAreaSize = currentAreaSize;
                    element = matrix[row, col];
                }
            }
        }
        Console.WriteLine("\nThe input matrix is: ");
        PrintMatrix();
        Console.WriteLine("\nThe largest area is from elements '{0}' and its size is {1} cells.", element, largestAreaSize);
    }

    // An implementation of the Depth First Search Algorithm -> http://en.wikipedia.org/wiki/Depth-first_search
    static void CalculateArea(int row, int col)
    {
        visitedCells[row, col] = true; // Current cell is now visited
        int currentElement = matrix[row, col];
        currentAreaSize++;
        if (ValidateCell(row - 1, col - 1) && matrix[row - 1, col - 1] == currentElement) // Upper left cell
        {
            CalculateArea(row - 1, col - 1);
        }
        if (ValidateCell(row - 1, col) && matrix[row - 1, col] == currentElement) // Upper cell
        {
            CalculateArea(row - 1, col);
        }
        if (ValidateCell(row - 1, col + 1) && matrix[row - 1, col + 1] == currentElement) // Upper right cell
        {
            CalculateArea(row - 1, col + 1); 
        }
        if (ValidateCell(row, col - 1) && matrix[row, col - 1] == currentElement) // Left cell
        {
            CalculateArea(row, col - 1);
        }
        if (ValidateCell(row, col + 1) && matrix[row, col + 1] == currentElement) // Right cell
        {
            CalculateArea(row, col + 1);
        }
        if (ValidateCell(row + 1, col - 1) && matrix[row + 1, col - 1] == currentElement) // Lower left cell
        {
            CalculateArea(row + 1, col - 1);
        }
        if (ValidateCell(row + 1, col) && matrix[row + 1, col] == currentElement) // Lower cell
        {
            CalculateArea(row + 1, col);
        }
        if (ValidateCell(row + 1, col + 1) && matrix[row + 1, col + 1] == currentElement) // Lower right cell
        {
            CalculateArea(row + 1, col + 1);
        }
    }

    static bool ValidateCell(int row, int col)
    {
        if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1)) // The cell is in the matrix
        {
            if (!visitedCells[row, col]) // The cell is not visited so far
            {
                return true;
            }
        }
        return false;
    }

    static void PrintMatrix()
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    static void FillMatrix()
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("Enter element at row {0} and column {1}: ", row + 1, col + 1);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }            
        }
    }
}
