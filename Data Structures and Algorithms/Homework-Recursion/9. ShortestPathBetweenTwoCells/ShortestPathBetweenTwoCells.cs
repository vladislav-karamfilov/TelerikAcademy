using System;

class ShortestPathBetweenTwoCells
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the shortest path between two cells in a matrix***");
        Console.Write(decorationLine);

        char[,] matrix = {
                            { '-', '-', '-', '*', '-', '-', '-', '-' },
                            { '*', '*', '*', '*', '-', '*', '-', '-' },
                            { '-', '-', '-', '*', '-', '*', '*', '-' },
                            { '-', '*', '*', '-', '*', '-', '-', '*' },
                            { '-', '-', '-', '-', '*', '-', '-', '*' },
                            { '*', '-', '-', '*', '*', '-', '-', '*' },
                            { '*', '*', '-', '*', '-', '-', '-', '*' },
                            { '*', '-', '-', '*', '-', '-', '*', '-' },
                            { '*', '-', '*', '*', '-', '-', '*', '-' }
                         };
        Console.WriteLine("The matrix is: ");
        PrintMatrix(matrix);
        Console.WriteLine();


    }

    static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0} ", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}
