using System;
using System.Collections.Generic;

class MostCommon
{
    static readonly Dictionary<string, int> byFirstNames = new Dictionary<string, int>();
    static readonly Dictionary<string, int> byLastNames = new Dictionary<string, int>();
    static readonly Dictionary<string, int> byYearsOfBirth = new Dictionary<string, int>();
    static readonly Dictionary<string, int> byEyeColors = new Dictionary<string, int>();
    static readonly Dictionary<string, int> byHairColors = new Dictionary<string, int>();
    static readonly Dictionary<string, int> byHeights = new Dictionary<string, int>();

    static readonly string[] mostCommons = { "zzz", "zzz", "zzz", "zzz", "zzz", "zzz" };

    static void Main()
    {
        InitializeDictionaries();

        int peopleCount = int.Parse(Console.ReadLine());
        char[] separators = { ',', ' ' };
        for (int i = 0; i < peopleCount; i++)
        {
            string[] personInfo =
                Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            AddToDictionary(personInfo[0], byFirstNames);
            UpdateMostCommon(personInfo[0], byFirstNames, 0);

            AddToDictionary(personInfo[1], byLastNames);
            UpdateMostCommon(personInfo[1], byLastNames, 1);

            AddToDictionary(personInfo[2], byYearsOfBirth);
            UpdateMostCommon(personInfo[2], byYearsOfBirth, 2);

            AddToDictionary(personInfo[3], byEyeColors);
            UpdateMostCommon(personInfo[3], byEyeColors, 3);

            AddToDictionary(personInfo[4], byHairColors);
            UpdateMostCommon(personInfo[4], byHairColors, 4);

            AddToDictionary(personInfo[5], byHeights);
            UpdateMostCommon(personInfo[5], byHeights, 5);
        }

        foreach (string mostCommon in mostCommons)
        {
            Console.WriteLine(mostCommon);
        }
    }

    static void InitializeDictionaries()
    {
        byFirstNames.Add(mostCommons[0], 0);
        byLastNames.Add(mostCommons[0], 0);
        byYearsOfBirth.Add(mostCommons[0], 0);
        byEyeColors.Add(mostCommons[0], 0);
        byHairColors.Add(mostCommons[0], 0);
        byHeights.Add(mostCommons[0], 0);
    }

    static void AddToDictionary(string characteristic, Dictionary<string, int> dictionary)
    {
        if (dictionary.ContainsKey(characteristic))
        {
            dictionary[characteristic]++;
        }
        else
        {
            dictionary.Add(characteristic, 1);
        }
    }

    static void UpdateMostCommon(string characteristic, Dictionary<string, int> dictionary, int dictionaryNumber)
    {
        if (dictionary[characteristic] > dictionary[mostCommons[dictionaryNumber]])
        {
            mostCommons[dictionaryNumber] = characteristic;
        }
        else if (dictionary[characteristic] == dictionary[mostCommons[dictionaryNumber]])
        {
            if (characteristic.CompareTo(mostCommons[dictionaryNumber]) < 0)
            {
                mostCommons[dictionaryNumber] = characteristic;
            }
        }
    }
}
