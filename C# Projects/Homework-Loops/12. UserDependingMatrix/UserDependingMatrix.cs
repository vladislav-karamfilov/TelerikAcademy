using System;

class UserDependingMatrix
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing a matrix depending on user's input of N !(0 < N < 20)!***");
        Console.Write(decorationLine);
        Console.Write("Enter N: ");
        byte n;
        while (!byte.TryParse(Console.ReadLine(), out n) || (n == 0) || (n >= 20))
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter N: ");
        }
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0,2}  ", row + col + 1);
            }
            Console.WriteLine();
        }
    }
}
