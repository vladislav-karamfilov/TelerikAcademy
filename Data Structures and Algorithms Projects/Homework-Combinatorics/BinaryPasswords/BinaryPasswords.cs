using System;
using System.Numerics;

class BinaryPasswords
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        BigInteger passwordsCount = 1;
        foreach (char symbol in inputLine)
        {
            if (symbol == '*')
            {
                passwordsCount *= 2;
            }
        }

        Console.WriteLine(passwordsCount);
    }
}