using System;
using System.Collections.Generic;

class LongestSubsequenceOfEqualNumbersFinder
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the longest subsequence of equal numbers in a list of integers***");
        Console.Write(decorationLine);

        try
        {
            Console.Write("Enter how many integers the list has: ");
            int inputIntegersCount = int.Parse(Console.ReadLine());
            if (inputIntegersCount <= 0)
            {
                throw new InvalidOperationException("Cannot have a list with non-positive elements count!");
            }

            List<int> inputIntegers = GetInputIntegers(inputIntegersCount);

            List<int> longestSubsequenceOfEqualNumbers = FindLongestSubsequenceOfEqualIntegers(inputIntegers);

            Console.Write("The longest subsequence of equal integers is: ");
            for (int index = 0; index < longestSubsequenceOfEqualNumbers.Count; index++)
            {
                Console.Write(longestSubsequenceOfEqualNumbers[index] + " ");
            }

            Console.WriteLine();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input number! The input is not an integer!");
            return;
        }
        catch (InvalidOperationException ioe)
        {
            Console.WriteLine(ioe.Message);
            return;
        }
    }

    static List<int> GetInputIntegers(int inputIntegersCount)
    {
        List<int> inputIntegers = new List<int>(inputIntegersCount);

        for (int index = 0; index < inputIntegersCount; index++)
        {
            Console.Write("Enter an integer number: ");
            inputIntegers.Add(int.Parse(Console.ReadLine()));
        }

        return inputIntegers;
    }

    private static List<int> FindLongestSubsequenceOfEqualIntegers(List<int> inputNumbers)
    {
        int inputNumbersCount = inputNumbers.Count;
        int currentElement = inputNumbers[0];
        int maxSubsequence = 1;
        int currentLength = 1;
        int maxSubsequenceStartIndex = 0; 

        for (int index = 1; index < inputNumbersCount; index++)
        {
            if (inputNumbers[index] == currentElement)
            {
                currentLength++;
                if (currentLength > maxSubsequence)
                {
                    maxSubsequence = currentLength;
                    maxSubsequenceStartIndex = index - maxSubsequence + 1;
                }
            }
            else
            {
                currentElement = inputNumbers[index];
                currentLength = 1;
            }
        }

        List<int> longestSubsequenceOfEqualIntegers = new List<int>();
        int bestLengthEndIndex = maxSubsequenceStartIndex + maxSubsequence;
        for (int index = maxSubsequenceStartIndex; index < bestLengthEndIndex; index++)
        {
            longestSubsequenceOfEqualIntegers.Add(inputNumbers[index]);
        }

        return longestSubsequenceOfEqualIntegers;
    }
}
