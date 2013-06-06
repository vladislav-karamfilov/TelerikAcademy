using System;

class LongestSequenceOfEqualStrings
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the longest sequence of strings in matrix of size N x M***");
        Console.Write(decorationLine);
        Console.Write("Enter how many rows N the matrix has: ");
        byte rows = byte.Parse(Console.ReadLine());
        Console.Write("Enter how many columns M the matrix has: ");
        byte columns = byte.Parse(Console.ReadLine());
        string[,] matrix = new string[rows, columns];
        for (byte row = 0; row < rows; row++)
        {
            for (byte col = 0; col < columns; col++)
            {
                Console.Write("Enter the string in row {0} and column {1}: ", row + 1, col + 1);
                matrix[row, col] = Console.ReadLine();
            }
        }
        byte longestSequence = 1; // There's at least one element
        // Scanning through the matrix to the right and diagonally (down + right)
        string word = matrix[0, 0];
        for (byte row = 0; row < rows; row++)
        {
            for (byte col = 0; col < columns; col++)
            {
                byte tempCol = (byte)col;
                byte currentLengthOnRight = 1;
                while (tempCol < columns - 1 && matrix[row, tempCol] == matrix[row, tempCol + 1])
                {
                    currentLengthOnRight++;
                    tempCol++;
                }
                if (currentLengthOnRight > longestSequence)
                {
                    longestSequence = currentLengthOnRight;
                    word = matrix[row, col];
                }
                tempCol = (byte)col;
                byte tempRow = (byte)row;
                byte currentLengthDiagonally = 1;
                while (tempCol < columns - 1 && tempRow < rows - 1 && matrix[tempRow, tempCol] == matrix[tempRow + 1, tempCol + 1])
                {
                    currentLengthDiagonally++;
                    tempRow++;
                    tempCol++;
                }
                if (currentLengthDiagonally > longestSequence)
                {
                    longestSequence = currentLengthDiagonally;
                    word = matrix[row, col];
                }
            }
        }
        for (byte col = 0; col < columns; col++)
        {
            for (byte row = 0; row < rows; row++)
            {
                byte tempRow = (byte)row;
                byte currentLengthDown = 1;
                while (tempRow < rows - 1 && matrix[tempRow, col] == matrix[tempRow + 1, col])
                {
                    currentLengthDown++;
                    tempRow++;
                }
                if (currentLengthDown > longestSequence)
                {
                    longestSequence = currentLengthDown;
                    word = matrix[row, col];
                }
            }
        }
        for (byte count = 0; count < longestSequence; count++)
        {
            if (count != longestSequence - 1)
            {
                Console.Write(word + ", ");
            }
            else
            {
                Console.WriteLine(word);
            }
        }
    }
}
