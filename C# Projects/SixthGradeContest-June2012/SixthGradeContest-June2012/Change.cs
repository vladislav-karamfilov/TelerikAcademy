using System;
using System.Numerics;

class Change
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        BigInteger s = BigInteger.Parse(input[0]);
        BigInteger p = BigInteger.Parse(input[1]);
        Console.WriteLine(s - p);
    }
}
