using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security;

class SortingSpecificWordsFromAFile
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding how many times words from a file are contained in another file ");
        Console.WriteLine("and sorting them by the number of occurrences in descending order***");
        Console.Write(decorationLine);
        // All files are in bin\Debug directory of the project
        string testFile = "Test.txt";
        string wordsFile = "Words.txt";
        string resultFile = "Result.txt";
        Console.WriteLine("The tested file is '{0}' and the words to test are in file '{1}'.", testFile, wordsFile);
        try
        {
            StreamReader reader = new StreamReader(wordsFile, Encoding.GetEncoding("UTF-8"));
            Dictionary<string, int> wordsOccurrences = new Dictionary<string, int>();
            using (reader)
            {
                string keyWord = reader.ReadLine();
                while (keyWord != null)
                {
                    wordsOccurrences.Add(keyWord, 0);
                    FindWordInFile(keyWord, testFile, wordsOccurrences);
                    keyWord = reader.ReadLine();
                }
            }
            // Sorting using lamba expression
            var sortedWordsOccurrences = from pair in wordsOccurrences
                                         orderby pair.Value descending
                                         select pair;
            StreamWriter writer = new StreamWriter(resultFile, false, Encoding.GetEncoding("UTF-8"));
            using (writer)
            {
                foreach (KeyValuePair<string, int> wordOccurrences in sortedWordsOccurrences)
                {
                    writer.WriteLine("{0} -> {1} occurrences", wordOccurrences.Key, wordOccurrences.Value);
                }
            }
            Console.WriteLine("Done! You can check the result in file '{0}'.", resultFile);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The specified directory was not found!");
        }
        catch (SecurityException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You don't have the required permission to access the file!");
        }
        catch (FileNotFoundException fileException)
        {
            Console.WriteLine("File '{0}' cannot be found.", fileException.FileName);
        }
        catch (ArgumentException argException)
        {
            Console.WriteLine(argException.Message);
        }
        catch (IOException)
        {
            Console.WriteLine("Fatal error occured!");
        }
    }

    static void FindWordInFile(string keyWord, string testFile, Dictionary<string, int> wordsOccurrences)
    {
        StreamReader reader = new StreamReader(testFile, Encoding.GetEncoding("UTF-8"));
        using (reader)
        {
            char currentChar = new char();
            string currentWord = null;
            while (!reader.EndOfStream)
            {
                currentChar = (char)reader.Read();
                // Using the definition that words consist of letters, digits, "-", "_" and "#"
                if (char.IsLetterOrDigit(currentChar) || currentChar == '-' || currentChar == '_' || currentChar == '#')
                {
                    currentWord += currentChar;
                }
                else
                {
                    if (currentWord == keyWord)
                    {
                        wordsOccurrences[keyWord]++;
                    }
                    currentWord = null;
                }
            }
            // Checking the last word if there is such
            if (currentWord != null && currentWord == keyWord)
            {
                wordsOccurrences[keyWord]++;
            }
        }
    }
}