using System;
using System.Collections.Generic;

class DecimalToBinaryConversion
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Converting a decimal number to its binary representation***");
        Console.Write(decorationLine);
        Console.Write("Enter a non-negative decimal number: ");
        ulong decimalNumber = ulong.Parse(Console.ReadLine());
        List<byte> binaryNumber = DecimalToBinary(decimalNumber);
        Console.Write("The binary representation of {0} is: ", decimalNumber);
        PrintBinary(binaryNumber);
    }

    static void PrintBinary(List<byte> binaryNumber)
    {
        foreach (byte bit in binaryNumber)
        {
            Console.Write(bit);
        }
        Console.WriteLine();
    }

    static List<byte> DecimalToBinary(ulong decimalNumber)
    {
        List<byte> binaryNumber = new List<byte>();
        while (decimalNumber != 0)
        {
            binaryNumber.Add((byte)(decimalNumber % 2));
            decimalNumber >>= 1;
        }
        binaryNumber.Reverse();
        return binaryNumber;
    }
}
