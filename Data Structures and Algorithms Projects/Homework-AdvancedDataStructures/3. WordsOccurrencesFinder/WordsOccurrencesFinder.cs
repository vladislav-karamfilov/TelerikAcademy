using System;
using System.IO;
using System.Collections.Generic;
using rmandvikar.Trie;

class WordsOccurrencesFinder
{
    static readonly Random RandomGenerator = new Random();

    static readonly string[] TextWords = new string[]
    {
        "to", "travel", "alone", "please", "work", "problem", "leave", "speak", "broken", "sun", "shop", "workshop",
        "ready", "project", "team", "pulse", "ice", "tool", "test", "architecture", "solution", "explore", "window", 
        "help", "view", "edit", "file", "just", "error", "warning", "window", "write", "read", "text", "word", "as",
        "find", "each", "many", "much", "large", "set", "table", "dog", "cat", "main", "sound", "music", "stop", "start",
        "live", "this", "these", "go", "away", "dozen", "forum", "academy", "immortal", "my", "your", "never", "late",
        "too", "one", "two", "number", "random", "click", "comment", "forever", "always", "bring", "me", "song", "remind",
        "wing", "can", "say", "talk", "argument", "compliment", "agree", "become", "be", "now", "hate", "what", "fallen"
    };

    static IList<string> wordsToFind = new List<string>()
    {
        "to", "item", "alone", "please", "work", "away", "leave", "speak", "load", "sun", "shop", "quick",
        "ready", "save", "team", "pulse", "ice", "tool", "test", "architecture", "solution", "explore", "window", 
        "open", "view", "edit", "file", "just", "character", "warning", "window", "write", "read", "text", "word", "as",
        "find", "each", "close", "much", "slow", "set", "table", "dog", "cat", "book", "sound", "mark", "stop", "start",
    };

    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding how many times each word from a set occurs in a large text***");
        Console.Write(decorationLine);

        //// Generate a text file of words with 110 MB size
        //string textFilePath = @"../../text.txt";
        //GenerateLargeTextFile(textFilePath); // Takes a few seconds

        // Generate a 1 000 000 words in the memory for faster testing
        string[] words = new string[1000000];
        for (int i = 0; i < 1000000; i++)
        {
            words[i] = TextWords[RandomGenerator.Next(0, TextWords.Length)];
        }

        ITrie wordsTrie = TrieFactory.GetTrie();
        foreach (string word in words)
        {
            wordsTrie.AddWord(word);
        }

        //// Get the words to find from a file
        //string wordsToFindFilePath = @"../../words-to-find.txt";
        //wordsToFind = GetWordsToFind(wordsToFindFilePath);

        Console.WriteLine("The words with their occurrences:");
        foreach (string word in wordsToFind)
        {
            Console.WriteLine("{0} -> {1}", word, wordsTrie.WordCount(word));
        }
    }

    private static IList<string> GetWordsToFind(string wordsFilePath)
    {
        IList<string> wordsToFind = new List<string>();
        using (StreamReader reader = new StreamReader(wordsFilePath))
        {
            string currentWord = reader.ReadLine();
            while (currentWord != null)
            {
                wordsToFind.Add(currentWord);
                currentWord = reader.ReadLine();
            }
        }

        return wordsToFind;
    }

    private static void GenerateLargeTextFile(string textFilePath)
    {
        using (StreamWriter writer = new StreamWriter(textFilePath))
        {
            int textWordsCount = TextWords.Length;
            int wordsToWrite = 20000000;
            for (int i = 0; i < wordsToWrite; i++)
            {
                writer.Write("{0} ", TextWords[RandomGenerator.Next(0, textWordsCount)]);
            }
        }
    }
}
