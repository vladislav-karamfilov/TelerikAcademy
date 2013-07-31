using System;
using System.Collections.Generic;
using System.Text;

class Crossword
{
    static string[] words;
    static HashSet<string> allWords;
    static string[] crossword;

    static void Main()
    {
        int crosswordSize = int.Parse(Console.ReadLine());
        crossword = new string[crosswordSize];
        words = new string[2 * crosswordSize];
        allWords = new HashSet<string>();
        for (int i = 0; i < 2 * crosswordSize; i++)
        {
            words[i] = Console.ReadLine();
            allWords.Add(words[i]);
        }

        Array.Sort(words);

        FindCrossword(0);

        Console.WriteLine("NO SOLUTION!");
    }

    static void FindCrossword(int currentLine)
    {
        if (currentLine == crossword.Length)
        {
            if (IsValidCrossword())
            {
                for (int row = 0; row < crossword.Length; row++)
                {
                    for (int col = 0; col < crossword.Length; col++)
                    {
                        Console.Write(crossword[row][col]);
                    }

                    Console.WriteLine();
                }

                Environment.Exit(0);
            }

            return;
        }

        foreach (string word in words)
        {
            crossword[currentLine] = word;
            FindCrossword(currentLine + 1);
            crossword[currentLine] = null;
        }
    }

    static bool IsValidCrossword()
    {
        StringBuilder currentWord = new StringBuilder();
        for (int row = 0; row < crossword.Length; row++)
        {
            for (int col = 0; col < crossword.Length; col++)
            {
                currentWord.Append(crossword[col][row]);
            }

            if (!allWords.Contains(currentWord.ToString()))
            {
                return false;
            }

            currentWord.Clear();
        }

        return true;
    }
}
