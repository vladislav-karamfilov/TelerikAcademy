using System;

class PrintNumberInDifferentWays
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Reading a number and printing it as decimal and hexadecimal number, percentage and in scientific notation***");
        Console.Write(decorationLine);
        Console.Write("Enter the number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("{0,15} -> decimal number", number);
        Console.WriteLine("{0,15:X} -> hexadecimal representation", number);
        Console.WriteLine("{0,15:P} -> number as percentage", (double)number / 100);
        Console.WriteLine("{0,15:E} -> number in scientific notation", number);
    }
}
