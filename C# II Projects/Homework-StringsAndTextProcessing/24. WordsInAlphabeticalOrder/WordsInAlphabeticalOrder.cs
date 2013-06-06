using System;

class WordsInAlphabeticalOrder
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Reading a list of words separated by spaces and printing them in \nalphabetical order***");
        Console.Write(decorationLine);
        Console.Write("Enter the list of words separated by spaces: ");
        char[] separator = { ' ' };
        string[] words = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(words);
        Console.WriteLine("The words in alphabetical order are: ");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}
