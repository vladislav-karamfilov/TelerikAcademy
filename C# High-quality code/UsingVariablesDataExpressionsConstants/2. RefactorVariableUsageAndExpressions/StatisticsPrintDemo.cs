using System;

namespace RefactorVariableUsageAndExpressions
{
    class StatisticsPrintDemo
    {
        static void Main(string[] args)
        {
            // Instantiating a random array of numbers
            double[] numbers = new double[] { -2.2, 12.421, -21.2, 7346.21, 325.6, 222, -121, -2111 };
            int numbersCount = numbers.Length;

            StatisticsPrinter printer = new StatisticsPrinter();
            printer.PrintStatistics(numbers, numbersCount);
        }
    }

    class StatisticsPrinter
    {
        public void PrintStatistics(double[] numbersArray, int numbersCount)
        {
            double maxElement = GetMax(numbersArray, numbersCount);
            PrintMax(maxElement);

            double minElement = GetMin(numbersArray, numbersCount);
            PrintMin(minElement);

            double average = GetAverage(numbersArray, numbersCount);
            PrintAverage(average);
        }

        private double GetMax(double[] numbersArray, int numbersCount)
        {
            double max = double.MinValue;
            for (int index = 0; index < numbersCount; index++)
            {
                if (numbersArray[index] > max)
                {
                    max = numbersArray[index];
                }
            }

            return max;
        }

        private void PrintMax(double maxNumber)
        {
            Console.WriteLine("The maximal number is: " + maxNumber);
        }

        private double GetMin(double[] numbersArray, int numbersCount)
        {
            double min = double.MaxValue;
            for (int index = 0; index < numbersCount; index++)
            {
                if (numbersArray[index] < min)
                {
                    min = numbersArray[index];
                }
            }

            return min;
        }

        private void PrintMin(double minNumber)
        {
            Console.WriteLine("The minimal number is: " + minNumber);
        }

        private double GetAverage(double[] numbersArray, int numbersCount)
        {
            double sum = 0;
            for (int index = 0; index < numbersCount; index++)
            {
                sum += numbersArray[index];
            }

            double average = sum / numbersCount;
            return average;
        }

        private void PrintAverage(double average)
        {
            Console.WriteLine("The average is: " + average);
        }
    }
}
