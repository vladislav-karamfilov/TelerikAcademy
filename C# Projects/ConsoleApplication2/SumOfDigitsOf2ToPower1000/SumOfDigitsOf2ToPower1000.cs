using System;
using System.Numerics;

class SumOfDigitsOf2ToPower1000
{
    static void Main()
    {
        BigInteger number = 1;
        for (int i = 0; i < 1000; i++)
        {
            number *= 2;
        }
        int sum = 0;
        while (number != 0)
        {
            sum += (int)(number % 10);
            number /= 10;
        }
        Console.WriteLine(sum);
    }
}
