using System;
using System.Collections.Generic;

class FactorialOfN
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating n! for each n in the range [1..100]***");
        Console.Write(decorationLine);
        List<byte> nFactorial = new List<byte>() { 1 };
        for (byte n = 1; n <= 100; n++)
        {
            nFactorial = MultiplyByN(nFactorial, n);
            Console.Write("{0}! = ", n);
            PrintNFactorial(nFactorial);
            nFactorial.Reverse(); // Preparing for the next iteration
        }
    }

    static List<byte> AddNumbers(List<byte> firstNumber, List<byte> secondNumber)
    {
        ushort maxDigits = (ushort)Math.Max(firstNumber.Count, secondNumber.Count);
        List<byte> result = new List<byte>();
        byte carry = 0;
        for (ushort digit = 0; digit < maxDigits; digit++)
        {
            byte resultDigit = 0;
            if (digit < firstNumber.Count)
            {
                resultDigit += firstNumber[digit];
            }
            if (digit < secondNumber.Count)
            {
                resultDigit += secondNumber[digit];
            }
            resultDigit += carry;
            result.Add((byte)(resultDigit % 10));
            if (resultDigit > 9)
            {
                carry = (byte)(resultDigit / 10);
            }
            else
            {
                carry = 0;
            }
        }
        if (carry != 0)
        {
            result.Add(carry);
        }
        return result;
    }
    // Using the definition for multiplication (e.g. 5 * 3 == 5 + 5 + 5)
    static List<byte> MultiplyByN(List<byte> nFactorial, byte n)
    {
        List<byte> result = nFactorial;
        for (byte count = 1; count < n; count++)
        {
            result = AddNumbers(result, nFactorial);
        }
        return result;
    }

    static void PrintNFactorial(List<byte> nFactorial)
    {
        nFactorial.Reverse(); // Reversing so the number is in corrent format
        foreach (byte digit in nFactorial)
        {
            Console.Write(digit);
        }
        Console.WriteLine();
    }
}