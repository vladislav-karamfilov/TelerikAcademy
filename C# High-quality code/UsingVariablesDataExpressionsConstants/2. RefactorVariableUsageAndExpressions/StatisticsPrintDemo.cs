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
            double maxNumber = GetMax(numbersArray, numbersCount);
            Print("The maximal number is: ", maxNumber);

            double minNumber = GetMin(numbersArray, numbersCount);
            Print("The minimal number is: ", minNumber);

            double average = GetAverage(numbersArray, numbersCount);
            Print("The average is: ", average);
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

        private void Print(string message, double number)
        {
            Console.WriteLine("{0}{1}", message, number);
        }
    }
}
