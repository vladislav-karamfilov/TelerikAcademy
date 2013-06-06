using System;

class SpecialPitagoreanTriplet
{
    static void Main(string[] args)
    {
        for (int i = 3; i <= 333; i++) // (100 - 3) / 3 -> because a < b < c
        {
            for (int j = i + 1; j < (999 - i) / 2; j++) // (1000 - 1 - i) / 2
            {
                if (i * i + j * j == (1000 - i - j) * (1000 - i - j)) // 1000 - i - j == c
                {
                    Console.WriteLine(i * j * (1000 - i - j));
                    return;
                }
            }
        }
    }
}
