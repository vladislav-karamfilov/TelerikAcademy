using System;
using System.Numerics;

class CalculatingDivisionOfFactorials
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating N!/K! where 1 < K < N***");
        Console.Write(decorationLine);
        Console.Write("Enter N: ");
        uint n;
        while (!uint.TryParse(Console.ReadLine(), out n) || n < 3)
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter N: ");
        }
        Console.Write("Enter K: ");
        uint k;
        while (!uint.TryParse(Console.ReadLine(), out k) || k < 2 || k >= n)
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter K: ");
        }
        BigInteger result = 1;
        uint difference = n - k;
        while (difference > 0)
        {
            result *= (k + difference);
            difference--;
        }
        Console.WriteLine("The result of the division {0}!/{1}! is {2}.", n, k, result);
    }
}
