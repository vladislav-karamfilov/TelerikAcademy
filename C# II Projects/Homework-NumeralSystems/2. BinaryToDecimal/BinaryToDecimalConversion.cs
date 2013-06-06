using System;

class BinaryToDecimalConversion
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Converting a binary number to its decimal representation***");
        Console.Write(decorationLine);
        Console.Write("Enter a binary number: ");
        string binaryNumber = Console.ReadLine();
        Console.WriteLine("The decimal representation of {0} is: {1}.", binaryNumber, BinaryToDecimal(binaryNumber));
    }
    static ulong BinaryToDecimal(string binaryNumber)
    {
        ulong result = 0;
        for (int index = 0; index < binaryNumber.Length; index++)
        {
            byte bit = (byte)(binaryNumber[index] - '0');
            result += (ulong)(bit * Math.Pow(2, binaryNumber.Length - index - 1));
        }
        return result;
    }
}
