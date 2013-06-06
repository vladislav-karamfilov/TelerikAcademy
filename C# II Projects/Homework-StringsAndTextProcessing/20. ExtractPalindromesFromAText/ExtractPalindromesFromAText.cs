using System;
using System.Collections.Generic;
using System.Text;

class ExtractPalindromesFromAText
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Extracting all palindromes from a text***");
        Console.Write(decorationLine);
        Console.Write("Enter the text to extract palindromes: ");
        string text = Console.ReadLine();
        List<string> palindromes = ExtractPalindromes(text);
        if (palindromes.Count != 0)
        {
            Console.WriteLine("All palindromes from the text are: ");
            foreach (string palindrom in palindromes)
            {
                Console.WriteLine(palindrom);
            }
        }
        else
        {
            Console.WriteLine("There are no palindromes in the text.");
        }
    }

    static List<string> ExtractPalindromes(string text)
    {
        List<string> palindromes = new List<string>();
        StringBuilder currentWord = new StringBuilder();
        foreach (char symbol in text)
        {
            if (char.IsLetterOrDigit(symbol) || symbol == '_')
            {
                currentWord.Append(symbol);
            }
            else
            {
                if (currentWord.Length != 0 && IsPalindrom(currentWord.ToString().ToLower()))
                {
                    palindromes.Add(currentWord.ToString());
                }
                currentWord.Clear();
            }
        }
        // Check for last word
        if (currentWord.Length != 0 && IsPalindrom(currentWord.ToString().ToLower()))
        {
            palindromes.Add(currentWord.ToString());
        }
        return palindromes;
    }

    static bool IsPalindrom(string currentWord)
    {
        int length = currentWord.Length;
        for (int index = 0; index < length / 2; index++)
        {
            if (currentWord[index] != currentWord[length - index - 1])
            {
                return false;
            }
        }
        return true;
    }
}
