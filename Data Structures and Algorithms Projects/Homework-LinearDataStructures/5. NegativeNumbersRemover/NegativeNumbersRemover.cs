using System;
using System.Collections.Generic;

class NegativeNumbersRemover
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Removing all negative numbers from a sequence***");
        Console.Write(decorationLine);

        try
        {
            Console.Write("Enter how many numbers the sequence has: ");
            int inputNumbersCount = int.Parse(Console.ReadLine());

            List<double> inputNumbers = new List<double>(inputNumbersCount);

            for (int index = 0; index < inputNumbersCount; index++)
            {
                Console.Write("Enter a number: ");
                double inputNumber = double.Parse(Console.ReadLine());
                inputNumbers.Add(inputNumber);
            }

            List<double> nonNegativeNumbers = RemoveNegativeNumbers(inputNumbers);

            Console.Write("The numbers after removing the negative ones are: ");
            foreach (double number in nonNegativeNumbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! You must enter a number!");
            return;
        }
    }

    static List<double> RemoveNegativeNumbers(List<double> inputNumbers)
    {
        List<double> nonNegativeNumbers = new List<double>();

        foreach (double number in inputNumbers)
        {
            if (number >= 0)
            {
                nonNegativeNumbers.Add(number);
            }
        }

        return nonNegativeNumbers;
    }
}
