using System;
using System.Text;

class ReplaceForbiddenWordsInText
{
    static StringBuilder newText = new StringBuilder();
    static int startIndex = 0;

    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Replacing all forbidden words in a text with asterisks***");
        Console.Write(decorationLine);
        Console.Write("Enter the text: ");
        string text = Console.ReadLine();
        Console.Write("Enter the forbidden words separated with spaces: ");
        char[] separator = new char[]{ ' ' };
        string[] forbiddenWords = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
        while (startIndex < text.Length)
        {
            string word = ExtractWordFromText(text);
            if (IsForbidden(word, forbiddenWords))
            {
                newText.Append(new string('*', word.Length));
            }
            else
            {
                newText.Append(word);
            }
            // Appending the symbol that separates the words
            if (startIndex < text.Length)
            {
                newText.Append(text[startIndex - 1]);
            }
        }
        Console.WriteLine("After the replacement the new text is:\n" + newText);
    }

    static bool IsForbidden(string word, string[] forbiddenWords)
    {
        foreach (string forbiddenWord in forbiddenWords)
        {
            if (word == forbiddenWord)
            {
                return true;
            }
        }
        return false;
    }

    static string ExtractWordFromText(string text)
    {
        StringBuilder currentWord = new StringBuilder();
        for (int index = startIndex; index < text.Length; index++)
        {
            startIndex++;
            if (char.IsLetterOrDigit(text[index]) || text[index] == '_')
            {
                currentWord.Append(text[index]);
            }
            else
            {
                break;
            }
        }
        return currentWord.ToString();
    }
}
