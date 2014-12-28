using System;
using System.Collections.Generic;

class DurankulakNumbers
{
    static void Main()
    {
        Dictionary<string, int> durankulakDigits = new Dictionary<string, int>(168);
        GetDurankulakDigits(durankulakDigits);

        string durankulakNumber = Console.ReadLine();
        int inputNumberLength = durankulakNumber.Length;
        string currentDurankulakDigit = null;
        List<int> decimalRepresentations = new List<int>();
        for (int i = 0; i < inputNumberLength; i++)
        {
            currentDurankulakDigit += durankulakNumber[i];
            if (char.IsUpper(durankulakNumber[i]))
            {
                decimalRepresentations.Add(durankulakDigits[currentDurankulakDigit]);
                currentDurankulakDigit = null;
            }
        }
        
        ulong decimalNumber = 0;
        int countOfDecimalRepresentations = decimalRepresentations.Count;
        for (int i = countOfDecimalRepresentations - 1; i >= 0; i--)
        {
            decimalNumber += (ulong)(decimalRepresentations[i] * Math.Pow(168, countOfDecimalRepresentations - i  - 1));
        }
        Console.WriteLine(decimalNumber);
    }

    static void GetDurankulakDigits(Dictionary<string, int> output)
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        for (int i = 0; i < 168; i++)
        {
            if (i < 26)
            {
                output.Add(alphabet[i].ToString(), i);
            }
            else if (i < 52)
            {
                output.Add("a" + alphabet[i - 26], i);
            }
            else if (i < 78)
            {
                output.Add("b" + alphabet[i - 52], i);
            }
            else if (i < 104)
            {
                output.Add("c" + alphabet[i - 78], i);
            }
            else if (i < 130)
            {
                output.Add("d" + alphabet[i - 104], i);
            }
            else if (i < 156)
            {
                output.Add("e" + alphabet[i - 130], i);
            }
            else
            {
                output.Add("f" + alphabet[i - 156], i);
            }
        }
    }
}
