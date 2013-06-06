using System;
using System.Numerics;

class FirstAHundredMembersOfFibonacciSequence
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing the first 100 members of the sequence of Fibunacci***");
        Console.Write(decorationLine);
        BigInteger firstMember = 0;
        BigInteger secondMember = 1;
        Console.WriteLine("1 member: {0}\n2 member: {1}", firstMember, secondMember);
        BigInteger temp = 0;
        for (int i = 3; i <= 100; i++)
        {
            temp = firstMember + secondMember;
            Console.WriteLine("{0} member: {1}", i, temp);
            firstMember = secondMember;
            secondMember = temp;
        }
    }
}
