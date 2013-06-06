using System;

class UnicodeFormatOfACharacterVariable
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Declaring a character variable and assigning it with\nthe symbol that has Unicode code 72***");
        Console.Write(decorationLine);
        char unicodeChar = '\u0048';
        Console.WriteLine("The character is {0}.", unicodeChar);
    }
}
