using System;
using System.Collections.Generic;

class NineGagNumbers
{
    static string[] nineGagDigits = new string[] { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };

    static void Main()
    {
        string nineGagNumber = Console.ReadLine();
        int nineGagNumberLength = nineGagNumber.Length;
        string currentNineGagDigit = "";
        int decimalDigit = 0;
        ulong decimalNumber = 0;
        List<int> decimalDigits = new List<int>();
        for (int i = 0; i < nineGagNumberLength; i++)
        {
            currentNineGagDigit += nineGagNumber[i];
            if (currentNineGagDigit.Length >= 2)
            {
                decimalDigit = GetDecimalDigit(currentNineGagDigit);
                if (decimalDigit >= 0)
                {
                    decimalDigits.Add(decimalDigit);
                    currentNineGagDigit = "";
                }
            }
        }
        int digitsCount = decimalDigits.Count;
        for (int i = digitsCount - 1; i >= 0; i--)
        {
            decimalNumber += (ulong)decimalDigits[i] * GetPower(9, digitsCount - i - 1);
        }
        Console.WriteLine(decimalNumber);
    }

    static ulong GetPower(ulong number, int power)
    {
        ulong result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= number;
        }
        return result;
    }

    static int GetDecimalDigit(string currentNineGagDigit)
    {
        for (int index = 0; index < 9; index++)
        {
            if (currentNineGagDigit == nineGagDigits[index])
            {
                return index;
            }
        }
        return -1;
    }
}
