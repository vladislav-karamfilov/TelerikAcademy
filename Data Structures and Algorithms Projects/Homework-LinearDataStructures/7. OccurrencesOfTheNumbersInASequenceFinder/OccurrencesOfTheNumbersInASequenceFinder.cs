using System;
using System.Collections.Generic;

class OccurrencesOfTheNumbersInASequenceFinder
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding how many times each integer occurs in a sequence***");
        Console.Write(decorationLine);

        Console.Write("Enter how many integers the sequence has: ");
        int inputIntegersCount = int.Parse(Console.ReadLine());

        List<int> inputIntegers = GetInputIntegersFromConsole(inputIntegersCount);

        inputIntegers.Sort();

        Console.WriteLine("All integers with their occurrences are: ");
        int currentInteger = inputIntegers[0];
        int currentIntegerOccurrences = 1;
        for (int index = 1; index < inputIntegersCount; index++)
        {
            if (currentInteger == inputIntegers[index])
            {
                currentIntegerOccurrences++;
            }
            else
            {
                Console.WriteLine(
                    "{0} -> {1} time{2}", 
                    currentInteger, 
                    currentIntegerOccurrences,
                    currentIntegerOccurrences > 1 ? "s" : "");

                currentIntegerOccurrences = 1;
                currentInteger = inputIntegers[index];
            }
        }

        // Printing the last number with its occurrences left in the "buffer"
        Console.WriteLine(
                    "{0} -> {1} time{2}",
                    currentInteger,
                    currentIntegerOccurrences,
                    currentIntegerOccurrences > 1 ? "s" : "");
    }

    static List<int> GetInputIntegersFromConsole(int inputIntegersCount)
    {
        List<int> inputIntegers = new List<int>(inputIntegersCount);

        for (int index = 0; index < inputIntegersCount; index++)
        {
            Console.Write("Enter an integer: ");
            int inputInteger = int.Parse(Console.ReadLine());
            inputIntegers.Add(inputInteger);
        }

        return inputIntegers;
    }
}
