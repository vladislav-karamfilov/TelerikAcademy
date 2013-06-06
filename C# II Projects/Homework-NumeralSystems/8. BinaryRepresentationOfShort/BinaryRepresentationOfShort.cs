using System;
using System.Text;

class BinaryRepresentationOfShort
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the binary representation of signed 16-bit integer number***");
        Console.Write(decorationLine);
        Console.Write("Enter an integer in the range [-32 768.. 32 767]: ");
        short number = short.Parse(Console.ReadLine());
        string binary = ShortToBinary(number);
        Console.WriteLine("The binary representation of {0} is: {1}.", number, binary);
    }

    static string ShortToBinary(short number)
    {
        // Special case -> the number is the minimal value for the "short": -32 768
        if (number == short.MinValue)
        {
            string binary = "1" + new string('0', 15);
            return binary;
        }
        if (number == 0)
        {
            return "0";
        }
        if (number < 0)
        {
            number = Math.Abs(number);
            string temp = PositiveToBinary(number);
            StringBuilder binary = new StringBuilder(temp.PadLeft(16, '0')); // The positive number with 0s at the beginning
            InvertBits(binary);
            AddOne(binary);
            return binary.ToString();
        }
        return PositiveToBinary(number);   
    }

    static void InvertBits(StringBuilder binary)
    {
        for (int index = 0; index < binary.Length; index++)
        {
            if (binary[index] == '0')
            {
                binary[index] = '1';
            }
            else
            {
                binary[index] = '0';
            }
        }
    }

    static void AddOne(StringBuilder binary)
    {
        for (int index = binary.Length - 1; index >= 0; index--)
        {
            if (binary[index] == '0')
            {
                binary[index] = '1';
                break;
            }
            binary[index] = '0';
        }
    }

    static string PositiveToBinary(short number)
    {
        string result = null;
        while (number != 0)
        {
            result += (char)(number % 2 + '0');
            number >>= 1;
        }
        // Reversing to get the correct representation
        char[] temp = result.ToCharArray();
        Array.Reverse(temp);
        result = new string(temp);
        return result;
    }
}
