using System;
using System.Collections.Generic;
using System.Linq;

class OddNumberOfTimesOccurringNumbersRemover
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Removing all numbers that occur odd number of times in a sequence***");
        Console.Write(decorationLine);

        Console.Write("Enter how many numbers the sequence has: ");
        int inputNumbersCount = int.Parse(Console.ReadLine());

        List<double> inputNumbers = new List<double>(inputNumbersCount);
        for (int index = 0; index < inputNumbersCount; index++)
        {
            Console.Write("Enter a number: ");
            double inputNumber = double.Parse(Console.ReadLine());
            inputNumbers.Add(inputNumber);
        }

        RemoveNumbersWithOddOccurrences(inputNumbers);

        Console.Write("\nThe sequence after removing all numbers occurring odd number of times is: ");
        foreach (double number in inputNumbers)
        {
            Console.Write("{0} ", number);
        }

        Console.WriteLine();
    }

    private static void RemoveNumbersWithOddOccurrences(List<double> inputNumbers)
    {
        int currentIndex = 0;
        while (currentIndex < inputNumbers.Count)
        {
            double currentNumber = inputNumbers[currentIndex];
            int currentNumberOccurrences = 0;
            for (int index = 0; index < inputNumbers.Count; index++)
            {
                if (inputNumbers[index] == currentNumber)
                {
                    currentNumberOccurrences++;
                }
            }

            if (currentNumberOccurrences % 2 != 0)
            {
                inputNumbers.RemoveAll(number => number == currentNumber);
                continue;
            }

            currentIndex++;
        }
    }
}
