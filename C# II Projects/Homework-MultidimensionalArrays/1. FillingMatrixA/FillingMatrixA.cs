using System;

class FillingMatrixA
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
        byte value = 1;
        for (byte row = 0; row < n; row++)
        {
            matrix[row, 0] = value;
            for (byte col = 1; col < n; col++)
            {
                matrix[row, col] = (ushort)(matrix[row, col - 1] + n);
            }
            value++;
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