using System;
using System.Numerics;

class AnotherDivisionOfFactorials
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the expression N! * K! / (K - N)! where 1 < N < K***");
        Console.Write(decorationLine);
        Console.Write("Enter K: ");
        uint k;
        while (!uint.TryParse(Console.ReadLine(), out k) || k < 3)
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter K: ");
        }
        Console.Write("Enter N: ");
        uint n;
        while (!uint.TryParse(Console.ReadLine(), out n) || n >= k || n < 2)
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter N: ");
        }
        BigInteger result = 1;
        for (int i = 1; i <= k; i++)
        {
            if (i <= n)
            {
                result *= i;
            }
            if (i >= (k - n + 1))
            {
                result *= i;
            }
        }
        Console.WriteLine("The result of the expression {0}! * {1}! / {2}! is {3}.", k, n, k - n, result);
    }
}
