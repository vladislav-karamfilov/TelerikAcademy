using System;
using System.Collections.Generic;
using System.Text;

class ReverseWordsInASentence
{
    static List<string> separators = new List<string>();
    static Stack<string> words = new Stack<string>();
        
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Reversing the words in a sentence***");
        Console.Write(decorationLine);
        Console.Write("Enter the sentence to reverse the words in: ");
        string sentence = Console.ReadLine();
        GetWordsAndSeparators(sentence);
        StringBuilder newSentence = ReverseWords(sentence);
        Console.WriteLine("The result of reversing the words:\n" + newSentence);
    }

    static StringBuilder ReverseWords(string sentence)
    {
        StringBuilder result = new StringBuilder();
        int index = 0;
        // The sentence starts with word
        if (char.IsLetterOrDigit(sentence[0]) || sentence[0] == '_' || sentence[0] == '\'' || sentence[0] == '#' || sentence[0] == '+')
        {
            while (words.Count != 0)
            {
                result.Append(words.Pop());
                if (index < separators.Count)
                {
                    result.Append(separators[index]);
                    index++;
                }
            }
        }
        else // The sentence starts with non-word
        {
            while (index < separators.Count)
            {
                result.Append(separators[index]);
                if (words.Count != 0)
                {
                    result.Append(words.Pop());
                }
                index++;
            }
        }
        return result;
    }

    static Stack<string> GetWordsAndSeparators(string sentence)
    {
        StringBuilder currentWord = new StringBuilder();
        StringBuilder currentSeparator = new StringBuilder();
        foreach (char symbol in sentence)
        {
            if (char.IsLetterOrDigit(symbol) || symbol == '_' || symbol == '\'' || symbol == '#' || symbol == '+')
            {
                currentWord.Append(symbol);
                if (currentSeparator.Length != 0)
                {
                    separators.Add(currentSeparator.ToString());
                    currentSeparator.Clear();
                }
            }
            else
            {
                currentSeparator.Append(symbol);
                if (currentWord.Length != 0)
                {
                    words.Push(currentWord.ToString());
                    currentWord.Clear();
                }
            }
        }
        // Push the last word/separator if there's any
        if (currentWord.Length != 0)
        {
            words.Push(currentWord.ToString());
        }
        if (currentSeparator.Length != 0)
        {
            separators.Add(currentSeparator.ToString());
        }
        return words;
    }
}
