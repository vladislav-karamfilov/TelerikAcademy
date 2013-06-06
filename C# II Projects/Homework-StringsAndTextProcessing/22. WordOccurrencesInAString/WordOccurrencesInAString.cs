using System;
using System.Collections.Generic;
using System.Text;

class WordOccurrencesInAString
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding how many times a word occurres in a text***");
        Console.Write(decorationLine);
        Console.Write("Enter the text to test: ");
        string text = Console.ReadLine();
        SortedDictionary<string, uint> wordsOccurrences = CountWordsOccurrences(text);
        if (wordsOccurrences.Count != 0)
        {
            Console.WriteLine("The words with their occurrences: ");
            foreach (KeyValuePair<string, uint> wordOccurrences in wordsOccurrences)
            {
                Console.WriteLine("{0} -> {1} times", wordOccurrences.Key, wordOccurrences.Value);
            }
        }
        else
        {
            Console.WriteLine("There are no words in the text.");
        }
    }

    static SortedDictionary<string, uint> CountWordsOccurrences(string text)
    {
        SortedDictionary<string, uint> result = new SortedDictionary<string, uint>();
        StringBuilder currentWord = new StringBuilder();
        foreach (char symbol in text)
        {
            if (char.IsLetterOrDigit(symbol))
            {
                currentWord.Append(symbol);
            }
            else
            {
                if (currentWord.Length != 0)
                {
                    if (result.ContainsKey(currentWord.ToString()))
                    {
                        result[currentWord.ToString()]++;
                    }
                    else
                    {
                        result.Add(currentWord.ToString(), 1);
                    }
                }
                currentWord.Clear();
            }
        }
        // Check last word if there's any
        if (currentWord.Length != 0)
        {
            if (result.ContainsKey(currentWord.ToString()))
            {
                result[currentWord.ToString()]++;
            }
            else
            {
                result.Add(currentWord.ToString(), 1);
            }
        }
        return result;
    }
}
