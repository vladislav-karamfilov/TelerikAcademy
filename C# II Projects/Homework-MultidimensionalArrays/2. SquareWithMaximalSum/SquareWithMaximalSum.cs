using System;

class SquareWithMaximalSum
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the square 3 x 3 that has the maximal sum in matrix of size N x M***");
        Console.Write(decorationLine);
        Console.Write("Enter how many rows N the matrix has: ");
        int rows = int.Parse(Console.ReadLine());
        if (rows < 3)
        {
            Console.WriteLine("The input is incorrect! You have to enter at least \"3\" for number of rows!");
            return;
        }
        Console.Write("Enter how many columns M the matrix has: ");
        int columns = int.Parse(Console.ReadLine());
        if (columns < 3)
        {
            Console.WriteLine("The input is incorrect! You have to enter at least \"3\" for number of columns!");
            return;
        }
        int[,] matrix = new int[rows, columns];
        // Filling the matrix
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.Write("Enter the number on row {0} and column {1}: ", row + 1, col + 1);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }
        // Printing the entered matrix
        Console.WriteLine("You have entered the following matrix: ");
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.Write("{0,-5}", matrix[row, col]);
            }
            Console.WriteLine();
        }
        // Finding the square 3 x 3 with maximal sum
        int maxSum = int.MinValue;
        int maxSumStartRow = 0;
        int maxSumStartCol = 0;
        for (int row = 0; row < rows - 2; row++)
        {
            for (int col = 0; col < columns - 2; col++)
            {
                int currentSquareSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + 
                    matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + 
                    matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (currentSquareSum > maxSum)
                {
                    maxSum = currentSquareSum;
                    maxSumStartRow = row;
                    maxSumStartCol = col;
                }
            }
        }
        Console.WriteLine("The following square has maximal sum of {0}: ", maxSum);
        Console.WriteLine("{0,-5}{1,-5}{2,-5}", matrix[maxSumStartRow, maxSumStartCol], 
            matrix[maxSumStartRow, maxSumStartCol + 1], matrix[maxSumStartRow, maxSumStartCol + 2]);
        Console.WriteLine("{0,-5}{1,-5}{2,-5}", matrix[maxSumStartRow + 1, maxSumStartCol],
            matrix[maxSumStartRow + 1, maxSumStartCol + 1], matrix[maxSumStartRow + 1, maxSumStartCol + 2]);
        Console.WriteLine("{0,-5}{1,-5}{2,-5}", matrix[maxSumStartRow + 2, maxSumStartCol],
            matrix[maxSumStartRow + 2, maxSumStartCol + 1], matrix[maxSumStartRow + 2, maxSumStartCol + 2]);
    }
}
