using System;
using System.Collections.Generic;

class KaspichanNumbers
{
    static Dictionary<int, string> representations = new Dictionary<int, string>(256);

    static void Main()
    {
        FillRepresentations();
        ulong decimalNumber = ulong.Parse(Console.ReadLine());
        List<string> result = new List<string>();
        int digit = 0;
        do
        {
            digit = (int)(decimalNumber % 256);
            result.Add(representations[digit]);
            decimalNumber /= 256;
        }
        while (decimalNumber != 0);
        for (int index = result.Count - 1; index >= 0; index--)
        {
            Console.Write(result[index]);
        }
        Console.WriteLine();
    }

    static void FillRepresentations()
    {
        string value = null;
        for (int i = 0; i < 256; i++)
        {
            if (i < 26)
            {
                value = ((char)('A' + i)).ToString();
            }
            else if (i < 52)
            {
                value = "a" + ((char)('A' + (i % 26))).ToString();
            }
            else if (i < 78)
            {
                value = "b" + ((char)('A' + (i % 26))).ToString();
            }
            else if (i < 104)
            {
                value = "c" + ((char)('A' + (i % 26))).ToString();
            }
            else if (i < 130)
            {
                value = "d" + ((char)('A' + (i % 26))).ToString();
            }
            else if (i < 156)
            {
                value = "e" + ((char)('A' + (i % 26))).ToString();
            }
            else if (i < 182)
            {
                value = "f" + ((char)('A' + (i % 26))).ToString();
            }
            else if (i < 208)
            {
                value = "g" + ((char)('A' + (i % 26))).ToString();
            }
            else if (i < 234)
            {
                value = "h" + ((char)('A' + (i % 26))).ToString();
            }
            else
            {
                value = "i" + ((char)('A' + (i % 26))).ToString();
            }
            representations.Add(i, value);
        }
    }
}
