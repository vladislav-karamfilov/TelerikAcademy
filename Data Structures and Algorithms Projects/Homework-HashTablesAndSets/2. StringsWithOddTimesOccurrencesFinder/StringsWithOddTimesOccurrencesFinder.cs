using System;
using System.Collections.Generic;

class StringsWithOddTimesOccurrencesFinder
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Getting all strings from a sequence that occur odd number of times***");
        Console.Write(decorationLine);

        List<string> strings = GetInputStrings();

        Dictionary<string, int> stringsOccurrences = GetStringsOccurrences(strings);

        Console.WriteLine("{0}All strings that occur odd number of times are:", Environment.NewLine);
        PrintOddTimesOccurrencesStrings(stringsOccurrences);
    }

    private static List<string> GetInputStrings()
    {
        List<string> inputStrings = new List<string>();
        while (true)
        {
            Console.Write("Enter a string (empty string to stop): ");
            string currentString = Console.ReadLine();
            if (currentString == string.Empty)
            {
                break;
            }

            inputStrings.Add(currentString);
        } 
        
        return inputStrings;
    }

    private static void PrintOddTimesOccurrencesStrings(Dictionary<string, int> stringsOccurrences)
    {
        foreach (var stringOccurrences in stringsOccurrences)
        {
            if (stringOccurrences.Value % 2 == 1)
            {
                Console.WriteLine(
                    "{0} -> {1} time{2}",
                    stringOccurrences.Key,
                    stringOccurrences.Value,
                    stringOccurrences.Value > 1 ? "s" : "");
            }
        }
    }

    private static Dictionary<string, int> GetStringsOccurrences(List<string> strings)
    {
        Dictionary<string, int> stringsOccurrences = new Dictionary<string, int>();
        foreach (string currentString in strings)
        {
            if (stringsOccurrences.ContainsKey(currentString))
            {
                stringsOccurrences[currentString]++;
            }
            else
            {
                stringsOccurrences[currentString] = 1;
            }
        }

        return stringsOccurrences;
    }
}
