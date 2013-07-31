using System;

class Divisors
{
    static readonly int[] numberAndDivisors = { int.MaxValue, int.MaxValue };

    static void Main()
    {
        byte sequenceLength = byte.Parse(Console.ReadLine());
        char[] digits = new char[sequenceLength];
        for (int i = 0; i < sequenceLength; i++)
        {
            digits[i] = char.Parse(Console.ReadLine());
        }

        Array.Sort(digits);
        GenerateNumbers(digits, 0);

        Console.WriteLine(numberAndDivisors[0]);
    }

    static void GenerateNumbers(char[] digits, int startIndex)
    {
        CountDivisors(digits);

        for (int left = digits.Length - 2; left >= startIndex; left--)
        {
            for (int right = left + 1; right < digits.Length; right++)
            {
                if (digits[left] != digits[right])
                {
                    Swap(ref digits[left], ref digits[right]);
                    GenerateNumbers(digits, left + 1);
                }
            }

            char firstElement = digits[left];
            for (int i = left; i < digits.Length - 1; i++)
            {
                digits[i] = digits[i + 1];
            }

            digits[digits.Length - 1] = firstElement;
        }
    }

    static void Swap(ref char first, ref char second)
    {
        char swapValue = first;
        first = second;
        second = swapValue;
    }

    static void CountDivisors(char[] digits)
    {
        int number = int.Parse(new string(digits));
        int divisorsCount = 2;
        for (int i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                divisorsCount++;
                if (divisorsCount > numberAndDivisors[1])
                {
                    return;
                }
            }
        }

        if (divisorsCount < numberAndDivisors[1])
        {
            numberAndDivisors[0] = number;
            numberAndDivisors[1] = divisorsCount;
        }
    }
}
