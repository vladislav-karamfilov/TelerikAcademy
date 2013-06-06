using System;

class HexadecimalToDecimalConversion
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Converting a hexadecimal number to its decimal representation***");
        Console.Write(decorationLine);
        Console.Write("Enter a hexadecimal number: ");
        string hexNumber = Console.ReadLine().ToUpper();
        ulong decimalNumber = HexadecimalToDecimal(hexNumber);
        Console.WriteLine("The decimal representation of {0} is: {1}.", hexNumber, decimalNumber);
    }
    static ulong HexadecimalToDecimal(string hexNumber)
    {
        ulong decimalNumber = 0;
        byte decimalDigit = 0;
        for (int index = 0; index < hexNumber.Length; index++)
        {
            if (hexNumber[index] >= '0' && hexNumber[index] <= '9')
            {
                decimalDigit = (byte)(hexNumber[index] - '0');
            }
            else
            {
                decimalDigit = (byte)(10 + hexNumber[index] - 'A');
            }
            decimalNumber += (ulong)(decimalDigit * Math.Pow(16, hexNumber.Length - index - 1));
        }
        return decimalNumber;
    }
}
