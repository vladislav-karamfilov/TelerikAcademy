using System;
using System.Collections.Generic;

class ASequenceOfIntegersSorter
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Sorting a sequence of integers***");
        Console.Write(decorationLine);

        try
        {
            List<int> inputIntegers = new List<int>();

            while (true)
            {
                Console.Write("Enter an integer number: ");
                string inputIntegerAsString = Console.ReadLine();
                if (inputIntegerAsString == string.Empty)
                {
                    break;
                }

                int inputInteger = int.Parse(inputIntegerAsString);
                inputIntegers.Add(inputInteger);
            }

            if (inputIntegers.Count == 0)
            {
                throw new InvalidOperationException("Cannot sort an empty list of integers!");
            }

            inputIntegers.Sort();

            int inputIntegersCount = inputIntegers.Count;
            Console.Write("\nThe sorted input numbers are: ");
            for (int index = 0; index < inputIntegersCount; index++)
            {
                Console.Write(inputIntegers[index] + " ");
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
}