using System;
using System.Collections.Generic;

class LetterOccurrencesInAString
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding how many times a letter occurres in a text***");
        Console.Write(decorationLine);
        Console.Write("Enter the text to test: ");
        string text = Console.ReadLine();
        SortedDictionary<char, uint> lettersOccurrences = CountLettersOccurrences(text);
        if (lettersOccurrences.Count != 0)
        {
            Console.WriteLine("The letter occurrences: ");
            foreach (KeyValuePair<char, uint> letterOccurrences in lettersOccurrences)
            {
                Console.WriteLine("{0} -> {1} times", letterOccurrences.Key, letterOccurrences.Value);
            }
        }
        else
        {
            Console.WriteLine("There are no letters in the text.");
        }
    }

    static SortedDictionary<char, uint> CountLettersOccurrences(string text)
    {
        SortedDictionary<char, uint> result = new SortedDictionary<char, uint>();
        foreach (char symbol in text)
        {
            if (char.IsLetter(symbol))
            {
                if (result.ContainsKey(symbol))
                {
                    result[symbol]++;
                }
                else
                {
                    result.Add(symbol, 1);
                }
            }
        }
        return result;
    }
}
