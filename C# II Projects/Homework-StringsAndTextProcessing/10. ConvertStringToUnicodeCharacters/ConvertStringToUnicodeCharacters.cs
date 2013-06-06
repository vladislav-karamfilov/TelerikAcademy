using System;

class ConvertStringToUnicodeCharacters
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Converting a string to a sequence of C# Unicode character literals***");
        Console.Write(decorationLine);
        Console.Write("Enter the string: ");
        string input = Console.ReadLine();
        foreach (char symbol in input)
        {
            Console.Write("\\u{0:X4}", (int)symbol);
        }
        Console.WriteLine();
    }
}
