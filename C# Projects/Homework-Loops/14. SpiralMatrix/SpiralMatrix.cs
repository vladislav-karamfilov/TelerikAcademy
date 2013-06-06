using System;

class SpiralMatrix
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing a spiral matrix depending on user's input of N !(0 < N < 20)!***");
        Console.Write(decorationLine);
        Console.Write("Enter N: ");
        byte n;
        while (!byte.TryParse(Console.ReadLine(), out n) || (n == 0) || (n >= 20))
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter N: ");
        }
        int number = 1;
        int[,] spiralMatrix = new int[n, n];
        // Forming a ring of numbers
        int ringFormer1 = n - 1;
        int ringFormer2 = 0;
        do
        {
            // Filling in the top row
            for (int col = ringFormer2; col < ringFormer1; col++)
            {
                spiralMatrix[ringFormer2, col] = number++;
            }
            // Filling in the rightmost column
            for (int row = ringFormer2; row < ringFormer1; row++)
            {
                spiralMatrix[row, ringFormer1] = number++;
            }
            // Filling in the bottom row
            for (int col = ringFormer1; col > ringFormer2; col--)
            {
                spiralMatrix[ringFormer1, col] = number++;
            }
            // Filling in the leftmost column
            for (int row = ringFormer1; row > ringFormer2; row--)
            {
                spiralMatrix[row, ringFormer2] = number++;
            }
            ringFormer2++;
            ringFormer1--;
        } while (ringFormer1 > 0);
        // Filling in the center cell if the matrix has an odd order number
        if (n % 2 != 0)
        {
            spiralMatrix[n / 2, n / 2] = number;
        }
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0, 4}", spiralMatrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
