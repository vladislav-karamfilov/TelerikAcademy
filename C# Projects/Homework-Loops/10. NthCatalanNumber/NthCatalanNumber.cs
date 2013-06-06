using System;
using System.Numerics;

class NthCatalanNumber
{
    static BigInteger CalculateFactorial(uint n)
    {
        BigInteger result = 1;
        while (n > 0)
        {
            result *= n;
            n--;
        }
        return result;
    }
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the N-th Catalan number***");
        Console.Write(decorationLine);
        Console.Write("Enter N: ");
        uint n;
        while (!uint.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter N: ");
        }
        BigInteger nCatalanNumber = CalculateFactorial(2 * n) / (CalculateFactorial(n + 1) * CalculateFactorial(n));
        Console.WriteLine("The {0}-th Catalan number is {1}.", n, nCatalanNumber);
    }
}