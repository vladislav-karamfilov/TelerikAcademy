using System;


class SevenlandNumbers
{
    static void Main()
    {
        string k = Console.ReadLine();
        int kDecimal = 0;
        for (int i = k.Length - 1; i >= 0; i--)
        {
            kDecimal += (k[i] - '0') * (int)Math.Pow(7, k.Length - 1 - i);
        }
        kDecimal++;
        string kPlusOne = null;
        while (kDecimal != 0)
        {
            kPlusOne += kDecimal % 7;
            kDecimal /= 7;
        }
        string answer = null;
        for (int i = kPlusOne.Length - 1; i >= 0; i--)
        {
            answer += kPlusOne[i];
        }
        Console.WriteLine(answer);
    }
}

