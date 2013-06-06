using System;

class HexadecimalFormatOfAnInteger
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Declaring an integer variable and assigning it with\nthe value 254 in hexadecimal format***");
        Console.Write(decorationLine);
        int hexadecimalInteger = 0xFE;
        Console.WriteLine("The integer in decimal format: {0} and in hexadecimal format: {0:X}.", hexadecimalInteger);
    }
}
