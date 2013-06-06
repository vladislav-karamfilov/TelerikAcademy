using System;

class FillingMatrixD
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Filling a matrix of size (n, n) like a spiral and printing it \non the console***");
        Console.Write(decorationLine);
        Console.Write("Enter the size n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] spiralMatrix = new int[n, n];
        int value = 1;
        // Forming a ring of numbers
        int ringFormer1 = 0;
        int ringFormer2 = n - 1;
        // Filling the spiral matrix
        do
        {
            // Filling the leftmost column
            for (int row = ringFormer1; row < ringFormer2; row++)
            {
                spiralMatrix[row, ringFormer1] = value++;
            }
            // Filling the bottom row
            for (int col = ringFormer1; col < ringFormer2; col++)
            {
                spiralMatrix[ringFormer2, col] = value++;
            }
            // Filling the rightmost column
            for (int row = ringFormer2; row > ringFormer1; row--)
            {
                spiralMatrix[row, ringFormer2] = value++;
            }
            // Filling the top row
            for (int col = ringFormer2; col > ringFormer1; col--)
            {
                spiralMatrix[ringFormer1, col] = value++;
            }
            ringFormer2--;
            ringFormer1++;
        } while (ringFormer2 > 0);
        // Filling in the center cell if the matrix has an odd order number
        if (n % 2 != 0)
        {
            spiralMatrix[n / 2, n / 2] = value;
        }
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0,-5}", spiralMatrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
