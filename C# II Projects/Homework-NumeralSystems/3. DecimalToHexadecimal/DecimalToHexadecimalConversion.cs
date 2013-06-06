using System;
using System.Text;

class DecimalToHexadecimalConversion
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Converting a decimal number to its hexadecimal representation***");
        Console.Write(decorationLine);
        Console.Write("Enter a non-negative decimal number: ");
        ulong decimalNumber = ulong.Parse(Console.ReadLine());
        StringBuilder hexNumber = DecimalToHexadecimal(decimalNumber);
        Console.WriteLine("The hexadecimal representation of {0} is: {1}.", decimalNumber, hexNumber);
    }
    static StringBuilder DecimalToHexadecimal(ulong decimalNumber)
    {
        StringBuilder hexNumber = new StringBuilder();
        char hexDigit = new char();
        while (decimalNumber != 0)
        {
            if (decimalNumber % 16 < 10)
            {
                hexDigit = (char)('0' + decimalNumber % 16);
            }
            else
            {
                hexDigit = (char)('A' + decimalNumber % 16 - 10);
            }
            hexNumber.Append(hexDigit);
            decimalNumber /= 16;
        }
        // Reversing the number to get the real value
        Reverse(hexNumber);
        return hexNumber;
    }

    static void Reverse(StringBuilder hexNumber)
    {
        for (int index = 0; index < hexNumber.Length / 2; index++)
        {
            if (hexNumber[index] != hexNumber[hexNumber.Length - index - 1])
            {
                char temp = hexNumber[index];
                hexNumber[index] = hexNumber[hexNumber.Length - index - 1];
                hexNumber[hexNumber.Length - index - 1] = temp;
            }
        }
    }
}
