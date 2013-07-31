using System;
using System.Collections.Generic;
using System.Text;

class Words
{
    static Dictionary<char, HashSet<string>> wordsByChar = new Dictionary<char, HashSet<string>>();

    static void Main()
    {
        InitializeWordsByChar();

        int textLinesCount = int.Parse(Console.ReadLine().ToLower());
        for (int i = 0; i < textLinesCount; i++)
        {
            GetWords(Console.ReadLine().ToLower());
        }

        int wordsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < wordsCount; i++)
        {
            string word = Console.ReadLine();
            string wordLowerCase = word.ToLower();
            HashSet<string> currentWords = new HashSet<string>();
            currentWords.UnionWith(wordsByChar[wordLowerCase[0]]);
            for (int j = 1; j < wordLowerCase.Length; j++)
            {
                currentWords.IntersectWith(wordsByChar[wordLowerCase[j]]);
            }

            Console.WriteLine("{0} -> {1}", word, currentWords.Count);
        }
    }

    static void InitializeWordsByChar()
    {
        for (char letter = 'a'; letter <= 'z'; letter++)
        {
            wordsByChar.Add(letter, new HashSet<string>());
        }
    }

    static void GetWords(string textLine)
    {
        StringBuilder word = new StringBuilder();
        foreach (char symbol in textLine)
        {
            if (char.IsLetter(symbol))
            {
                word.Append(symbol);
            }
            else
            {
                if (word.Length > 0)
                {
                    AddWordToHashSet(word.ToString());
                }

                word.Clear();
            }
        }

        if (word.Length > 0)
        {
            AddWordToHashSet(word.ToString());
        }
    }

    static void AddWordToHashSet(string word)
    {
        foreach (char letter in word)
        {
            if (!wordsByChar[letter].Contains(word))
            {
                wordsByChar[letter].Add(word);
            }
        }
    }
}
