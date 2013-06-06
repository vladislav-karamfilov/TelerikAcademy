using System;
using System.Collections.Generic;

class TranslateWordFromDictionary
{
    static Dictionary<string, string> dictionary = new Dictionary<string, string>
    {
        {".NET", "platform for applications from Microsoft"},
        {"CLR", "managed execution environment for .NET"},
        {"namespace", "hierarchical organization of classes"}
    };

    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Translating a word from dictionary (the dictionary is in the source code)***");
        Console.Write(decorationLine);
        Console.Write("Enter the word to translate: ");
        string word = Console.ReadLine();
        foreach (KeyValuePair<string, string> wordAndDefinition in dictionary)
        {
            if (wordAndDefinition.Key == word)
            {
                Console.WriteLine("The translation of '{0}' -> '{1}'", word, wordAndDefinition.Value);
                return;
            }
        }
        Console.WriteLine("There is no such word in the dictionary!");
    }
}
