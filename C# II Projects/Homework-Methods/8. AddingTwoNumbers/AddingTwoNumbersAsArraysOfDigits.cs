using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Adding two positive integer numbers represented as arrays of digits***");
        Console.Write(decorationLine);
        Console.Write("Enter how many digits the first number has: ");
        ushort digits1 = ushort.Parse(Console.ReadLine());
        byte[] firstNumber = new byte[digits1];
        EnterDigits(firstNumber, digits1);
        Console.Write("Enter how many digits the second number has: ");
        ushort digits2 = ushort.Parse(Console.ReadLine());
        byte[] secondNumber = new byte[digits2];
        EnterDigits(secondNumber, digits2);
        List<byte> result = AddIntegers(firstNumber, secondNumber);
        Console.Write("The result from the addition is: ");
        PrintResult(result); 
    }

    static List<byte> AddIntegers(byte[] firstNumber, byte[] secondNumber)
    {
        ushort maxDigits = (ushort)Math.Max(firstNumber.Length, secondNumber.Length);
        List<byte> result = new List<byte>();
        byte carry = 0;
        for (ushort digit = 0; digit < maxDigits; digit++)
        {
            byte resultDigit = 0;
            if (digit < firstNumber.Length)
            {
                resultDigit += firstNumber[digit];
            }
            if (digit < secondNumber.Length)
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
        result.Reverse();
        return result;
    }
    // Entering in reverse order so the calculations are easier
    static void EnterDigits(byte[] firstNumber, ushort digits)
    {
        for (int digit = digits - 1; digit >= 0; digit--)
        {
            Console.Write("Enter a digit: ");
            firstNumber[digit] = byte.Parse(Console.ReadLine());
        }
    }

    static void PrintResult(List<byte> result)
    {
        foreach (byte digit in result)
        {
            Console.Write(digit);
        }
        Console.WriteLine();
    }
}
