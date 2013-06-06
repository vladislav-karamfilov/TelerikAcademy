using System;

class BinaryToHexadecimalConversion
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Converting a binary number to its hexadecimal representation***");
        Console.Write(decorationLine);
        Console.Write("Enter a binary number: ");
        string binaryNumber = Console.ReadLine();
        string hexNumber = BinaryToHexadecimal(binaryNumber);
        Console.WriteLine("The binary representation of {0} is: {1}.", binaryNumber, hexNumber);
    }

    static string BinaryToHexadecimal(string binaryNumber)
    {
        string result = null;
        binaryNumber = AddLeadingZeroes(binaryNumber);
        for (int bit = 0; bit < binaryNumber.Length; bit += 4)
        {
            string halfByte = binaryNumber.Substring(bit, 4);
            switch (halfByte)
            {
                case "0001":
                    result += "1";
                    break;
                case "0010":
                    result += "2";
                    break;
                case "0011":
                    result += "3";
                    break;
                case "0100":
                    result += "4";
                    break;
                case "0101":
                    result += "5";
                    break;
                case "0110":
                    result += "6";
                    break;
                case "0111":
                    result += "7";
                    break;
                case "1000":
                    result += "8";
                    break;
                case "1001":
                    result += "9";
                    break;
                case "1010":
                    result += "A";
                    break;
                case "1011":
                    result += "B";
                    break;
                case "1100":
                    result += "C";
                    break;
                case "1101":
                    result += "D";
                    break;
                case "1110":
                    result += "E";
                    break;
                case "1111":
                    result += "F";
                    break;
                default: // "0000"
                    result += "0";
                    break;
            }
        }
        return result;
    }

    static string AddLeadingZeroes(string binaryNumber)
    {
        byte leadingZeroes = 0;
        if (binaryNumber.Length % 4 != 0)
        {
            leadingZeroes = (byte)(4 - binaryNumber.Length % 4);
        }
        string zeroes = new string('0', leadingZeroes);
        return zeroes + binaryNumber;
    }
}
