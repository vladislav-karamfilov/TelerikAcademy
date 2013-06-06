using System;
using System.Text;

class ReplaceIdenticalLettersWithOneLetter
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Replacing all series of consecutive identical letters with a single one \nin an input text***");
        Console.Write(decorationLine);
        Console.Write("Enter the text to test: ");
        string text = Console.ReadLine();
        StringBuilder transformedText = ReplaceIdenticalLetters(text);
        Console.WriteLine("After the replacement the new text is: " + transformedText);
    }

    static StringBuilder ReplaceIdenticalLetters(string text)
    {
        StringBuilder result = new StringBuilder();
        char currentLetter = new char();
        foreach (char symbol in text)
        {
            if (char.IsLetter(symbol))
            {
                if (symbol != currentLetter)
                {
                    result.Append(symbol);
                    currentLetter = symbol;
                }
            }
            else if (!char.IsLetter(symbol))
            {
                result.Append(symbol);
                currentLetter = '\0';
            }
        }
        return result;
    }
}
