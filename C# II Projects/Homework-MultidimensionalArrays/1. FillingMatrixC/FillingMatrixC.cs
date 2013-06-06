using System;

class FillingMatrixC
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Filling a matrix of size (n, n) diagonally from the left bottom cell upwards and printing it on the console***");
        Console.Write(decorationLine);
        Console.Write("Enter the size n: ");
        byte n = byte.Parse(Console.ReadLine());
        ushort[,] matrix = new ushort[n, n];
        int startingRow = n - 1;
        ushort value = 1;
        // Filling the main diagonal and the cells below
        while (startingRow >= 0)
        {
            byte row = (byte)startingRow;
            byte col = 0;
            while (row < n && col < n)
            {
                matrix[row, col] = value;
                value++;
                row++;
                col++;
            }
            startingRow--;
        }
        // Filling the cells above the main diagonal
        byte startingCol = 1;
        while (startingCol < n)
        {
            byte row = 0;
            byte col = (byte)startingCol;
            while (col < n)
            {
                matrix[row, col] = value;
                value++;
                row++;
                col++;
            }
            startingCol++;
        }
        // Printing the matrix
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0,-5}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
