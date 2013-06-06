using System;
using System.Text;

class HexadecimalToBinaryConversion
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Converting a hexadecimal number to its binary representation***");
        Console.Write(decorationLine);
        Console.Write("Enter a hexadecimal number: ");
        string hexNumber = Console.ReadLine().ToUpper();
        StringBuilder binaryNumber = HexadecimalToBinary(hexNumber);
        Console.WriteLine("The binary representation of {0} is: {1}", hexNumber, binaryNumber);
    }

    static StringBuilder HexadecimalToBinary(string hexNumber)
    {
        StringBuilder result = new StringBuilder();
        foreach (char hexDigit in hexNumber)
        {
            switch (hexDigit)
            {
                case '1':
                    result.Append("0001");
                    break;
                case '2':
                    result.Append("0010");
                    break;
                case '3':
                    result.Append("0011");
                    break;
                case '4':
                    result.Append("0100");
                    break;
                case '5':
                    result.Append("0101");
                    break;
                case '6':
                    result.Append("0110");
                    break;
                case '7':
                    result.Append("0111");
                    break;
                case '8':
                    result.Append("1000");
                    break;
                case '9':
                    result.Append("1001");
                    break;
                case 'A':
                    result.Append("1010");
                    break;
                case 'B':
                    result.Append("1011");
                    break;
                case 'C':
                    result.Append("1100");
                    break;
                case 'D':
                    result.Append("1101");
                    break;
                case 'E':
                    result.Append("1110");
                    break;
                case 'F':
                    result.Append("1111");
                    break;
                default: // Using it to represent 0 
                    result.Append("0000");
                    break;
            }
            result.Append(" ");
        }
        RemoveLeadingZeroes(result);
        return result;
    }

    static void RemoveLeadingZeroes(StringBuilder result)
    {
        while (result[0] == '0')
        {
            result.Remove(0, 1);
        }
    }
}
