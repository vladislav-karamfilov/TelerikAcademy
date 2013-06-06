using System;
using System.Numerics;

class FirstNMembersOfTheFibonacciSequence
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing the first N members of the sequence of Fibonacci***");
        Console.Write(decorationLine);
        Console.Write("Enter N: ");
        uint n;
        while (!uint.TryParse(Console.ReadLine(), out n) || n == 0)
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter N: ");
        }
        BigInteger firstMember = 0;
        BigInteger secondMember = 1;
        Console.WriteLine("1 member -> {0}\n2 member -> {1}", firstMember, secondMember);
        for (uint i = 3; i <= n; i++)
        {
            BigInteger newMember = firstMember + secondMember;
            Console.WriteLine("{0} member -> {1}", i, newMember);
            firstMember = secondMember;
            secondMember = newMember;
        }
    }
}