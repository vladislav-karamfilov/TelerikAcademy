using System;
using System.Collections.Generic;
using System.Linq;

class SumAndAverageOfPositiveIntegersCalculator
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the sum and the average of a sequence of positive integers***");
        Console.Write(decorationLine);

        try
        {
            List<int> positiveIntegers = new List<int>();

            while (true)
            {
                Console.Write("Enter a positive integer (to stop enter an empty line): ");
                string inputNumberAsString = Console.ReadLine();

                if (inputNumberAsString == string.Empty)
                {
                    break;
                }

                int inputNumber = int.Parse(inputNumberAsString);
                if (inputNumber <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                positiveIntegers.Add(inputNumber);
            }

            long sum = positiveIntegers.Sum();

            double average = 0;
            if (positiveIntegers.Count > 0)
            {
                average = (double)sum / positiveIntegers.Count;
            }

            Console.WriteLine();

            Console.WriteLine("The sum of the input numbers is: {0}", sum);
            Console.WriteLine("The average of the input numbers is: {0}", average);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("The input numbers must be positive!");
            return;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input number! The input is not an integer!");
            return;
        }
    }
}
