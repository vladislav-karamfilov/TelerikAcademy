using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;

class WordsInAFileSorterByOccurrences
{
    private const string WordsFilePath = "../../words.txt";

    private static readonly string[] WordsSeparators = new string[] 
    { 
        " ", ",", ".", "!", "-", ":", ";", "\"", "'", Environment.NewLine,
        "\\", "/", "^", "&", "%", "=", "@", "~", "(", "*",
        ")", "$", "[", "]", "`", "{", "}", ">", "<", "|" 
    };

    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Getting the number of occurrences of all words in a text file and sorting");
        Console.WriteLine("them by number of occurrences. The performed search is case-insensitive!***");
        Console.Write(decorationLine);

        Dictionary<string, int> wordsOccurrences = null;
        try
        {
            wordsOccurrences = GetWordsOccurrences();
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The specified directory was not found!");
            return;
        }
        catch (SecurityException se)
        {
            Console.WriteLine(se.Message);
            return;
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You don't have the required permission to access the file!");
            return;
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine("File '{0}' cannot be found.", fnfe.FileName);
            return;
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
            return;
        }
        catch (IOException)
        {
            Console.WriteLine("Fatal error occured!");
            return;
        }

        var sortedWordsOccurrences = from wordOccurrences in wordsOccurrences
                                     orderby wordOccurrences.Value ascending
                                     select wordOccurrences;

        StringBuilder wordsOccurrencesString = GetWordsOccurrencesString(sortedWordsOccurrences);
        Console.Write(wordsOccurrencesString);
    }

    private static StringBuilder GetWordsOccurrencesString(IOrderedEnumerable<KeyValuePair<string, int>> wordsOccurrences)
    {
        StringBuilder output = new StringBuilder();
        foreach (KeyValuePair<string, int> wordOccurrences in wordsOccurrences)
        {
            output.AppendFormat(
                    "{0} -> {1} time{2}{3}",
                    wordOccurrences.Key,
                    wordOccurrences.Value,
                    wordOccurrences.Value > 1 ? "s" : "",
                    Environment.NewLine);
        }

        return output;
    }

    private static Dictionary<string, int> GetWordsOccurrences()
    {
        Dictionary<string, int> wordsOccurrences = new Dictionary<string, int>();
        using (StreamReader reader = new StreamReader(WordsFilePath))
        {
            string fileContent = reader.ReadToEnd();

            string[] words = fileContent.Split(WordsSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                string lowerCaseWord = word.ToLowerInvariant();
                if (wordsOccurrences.ContainsKey(lowerCaseWord))
                {
                    wordsOccurrences[lowerCaseWord]++;
                }
                else
                {
                    wordsOccurrences[lowerCaseWord] = 1;
                }
            }
        }

        return wordsOccurrences;
    }
}
