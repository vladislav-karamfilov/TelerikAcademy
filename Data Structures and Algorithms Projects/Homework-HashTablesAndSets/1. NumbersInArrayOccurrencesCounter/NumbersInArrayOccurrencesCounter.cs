using System;
using System.Collections.Generic;

class NumbersInArrayOccurrencesCounter
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Counting the occurrences of each element in an array of numbers***");
        Console.Write(decorationLine);

        Console.Write("Enter the count of numbers in the array: ");
        int numbersCount = int.Parse(Console.ReadLine());
        double[] numbers = GetInputNumbers(numbersCount);

        Dictionary<double, int> numbersOccurrences = GetNumbersOccurrences(numbers);

        Console.WriteLine("{0}Numbers occurrences:", Environment.NewLine);
        PrintNumbersOccurrences(numbersOccurrences);
    }

    private static void PrintNumbersOccurrences(Dictionary<double, int> numbersOccurrences)
    {
        foreach (var numberOccurrences in numbersOccurrences)
        {
            Console.WriteLine(
                "{0} -> {1} time{2}",
                numberOccurrences.Key,
                numberOccurrences.Value,
                numberOccurrences.Value > 1 ? "s" : "");
        }
    }

    private static Dictionary<double, int> GetNumbersOccurrences(double[] numbers)
    {
        Dictionary<double, int> numbersOccurrences = new Dictionary<double, int>();
        foreach (double currentNumber in numbers)
        {
            if (numbersOccurrences.ContainsKey(currentNumber))
            {
                numbersOccurrences[currentNumber]++;
            }
            else
            {
                numbersOccurrences[currentNumber] = 1;
            }
        }

        return numbersOccurrences;
    }

    private static double[] GetInputNumbers(int count)
    {
        double[] inputNumbers = new double[count];
        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter a number: ");
            inputNumbers[i] = double.Parse(Console.ReadLine());
        }

        return inputNumbers;
    }
}
