using System;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        BigInteger first = BigInteger.Parse(Console.ReadLine()); 
        BigInteger second = BigInteger.Parse(Console.ReadLine());
        BigInteger third = BigInteger.Parse(Console.ReadLine());
        ushort n = ushort.Parse(Console.ReadLine()); // The element we want to calculate
        if (n == 1)
        {
            Console.WriteLine(first);
        }
        else if (n == 2)
        {
            Console.WriteLine(second);
        }
        else
        {
            BigInteger result = third;
            for (ushort i = 4; i <= n; i++)
            {
                result = first + second + third;
                first = second;
                second = third;
                third = result;
            }
            Console.WriteLine(result);
        }
    }
}
