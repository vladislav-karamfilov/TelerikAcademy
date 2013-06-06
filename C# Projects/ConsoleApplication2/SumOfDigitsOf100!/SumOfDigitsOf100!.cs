using System;
using System.Numerics;

class SumOfDigitsOf100Factorial
{
    static void Main()
    {
        BigInteger factorial = 1;
        for (int i = 2; i <= 100; i++)
        {
            factorial *= i;
        }
        int sumOfDigits = 0;
        while (factorial != 0)
        {
            sumOfDigits += (int)(factorial % 10);
            factorial /= 10;
        }
        Console.WriteLine(sumOfDigits);
    }
}
