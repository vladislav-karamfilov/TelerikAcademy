using System;
using System.Collections.Generic;

class SevenSegmentDigits
{
    static readonly byte[] digits = new byte[]
    {
        Convert.ToByte("1111110", 2),
        Convert.ToByte("0110000", 2),
        Convert.ToByte("1101101", 2),
        Convert.ToByte("1111001", 2),
        Convert.ToByte("0110011", 2),
        Convert.ToByte("1011011", 2),
        Convert.ToByte("1011111", 2),
        Convert.ToByte("1110000", 2),
        Convert.ToByte("1111111", 2),
        Convert.ToByte("1111011", 2)
    };
    static byte[] segments;
    
    static List<string> possibleNumbers;
    static char[] currentNumber;

    static void Main()
    {
        int segmentsCount = int.Parse(Console.ReadLine());
        segments = new byte[segmentsCount];
        currentNumber = new char[segmentsCount];
        for (int i = 0; i < segmentsCount; i++)
        {
            segments[i] = Convert.ToByte(Console.ReadLine(), 2);
        }

        possibleNumbers = new List<string>();
        GetPossibleNumbers(0);

        Console.WriteLine(possibleNumbers.Count);
        foreach (string possibleNumber in possibleNumbers)
        {
            Console.WriteLine(possibleNumber);
        }
    }

    static void GetPossibleNumbers(int digitPosition)
    {
        if (digitPosition == segments.Length)
        {
            possibleNumbers.Add(new string(currentNumber));
            return;
        }

        for (int i = 0; i < digits.Length; i++)
        {
            if ((digits[i] & segments[digitPosition]) == segments[digitPosition])
            {
                currentNumber[digitPosition] = (char)('0' + i);
                GetPossibleNumbers(digitPosition + 1);
            }
        }
    }
}
