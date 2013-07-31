using System;
using System.Numerics;

class Businessmen
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()) / 2;
        Console.WriteLine(CalculateFactorial(2 * n) / (CalculateFactorial(n + 1) * CalculateFactorial(n)));
    }

    static BigInteger CalculateFactorial(int n)
    {
        BigInteger result = 1;
        while (n > 0)
        {
            result *= n;
            n--;
        }

        return result;
    }
}
