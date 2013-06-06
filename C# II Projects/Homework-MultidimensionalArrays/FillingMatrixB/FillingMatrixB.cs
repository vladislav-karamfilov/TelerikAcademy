using System;

class FillingMatrixB
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Filling a matrix of size (n, n) column by column and printing it \non the console***");
        Console.Write(decorationLine);
        Console.Write("Enter the size n: ");
        byte n = byte.Parse(Console.ReadLine());
        ushort[,] matrix = new ushort[n, n];
        // Filling the matrix
        ushort oddColValue = 1;
        byte evenColMultiplier = 2;
        for (byte col = 0; col < n; col++)
        {
            if (col % 2 == 1)
            {
                matrix[0, col] = (ushort)(evenColMultiplier * n);
                for (byte row = 1; row < n; row++)
                {
                    matrix[row, col] = (ushort)(matrix[row - 1, col] - 1);
                }
                evenColMultiplier += 2;
            }
            else
            {
                matrix[0, col] = oddColValue;
                for (byte row = 1; row < n; row++)
                {
                    matrix[row, col] = (ushort)(matrix[row - 1, col] + 1);
                }
                oddColValue = (ushort)(n * evenColMultiplier + 1);
            }
        }
        // Printing the matrix
        for (byte row = 0; row < n; row++)
        {
            for (byte col = 0; col < n; col++)
            {
                Console.Write("{0,-5}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
