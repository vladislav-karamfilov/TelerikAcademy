namespace SortingPerformanceComparison
{
    using System;
    using System.Diagnostics;

    public class SortingPerformanceComparison
    {
        private const int ArrayLength = 10000;
        
        private static readonly Stopwatch Watch = new Stopwatch();
        private static readonly Random RandomGenerator = new Random();

        public static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Comparing the performance of insertion sort, selection sort and quicksort");
            Console.WriteLine("for int, double and string values***");
            Console.Write(decorationLine);

            Console.WriteLine("---Tests with integers---");
            PrintRandomIntegersTests();
            Console.WriteLine();

            PrintSortedIntegersTests();
            Console.WriteLine();

            PrintReversedIntegersTests();
            Console.WriteLine();

            Console.WriteLine("---Tests with doubles---");
            PrintRandomDoublesTests();
            Console.WriteLine();

            PrintSortedDoublesTests();
            Console.WriteLine();

            PrintReversedDoublesTests();
            Console.WriteLine();

            Console.WriteLine("---Tests with strings---");
            PrintRandomStringsTests();
            Console.WriteLine();

            PrintSortedStringsTests();
            Console.WriteLine();

            PrintReversedStringsTests();
        }

        private static void PrintReversedIntegersTests()
        {
            int[] reversedIntegers = new int[ArrayLength];

            GetReversedIntegers(reversedIntegers);
            Watch.Restart();
            Sorter<int>.InsertionSort(reversedIntegers);
            Console.WriteLine("Insertion sort of {0} reversed integers takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetReversedIntegers(reversedIntegers);
            Watch.Restart();
            Sorter<int>.SelectionSort(reversedIntegers);
            Console.WriteLine("Selection sort of {0} reversed integers takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetReversedIntegers(reversedIntegers);
            Watch.Restart();
            Sorter<int>.QuickSort(reversedIntegers);
            Console.WriteLine("Quicksort of {0} reversed integers takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);
        }

        private static void PrintSortedIntegersTests()
        {
            int[] sortedIntegers = new int[ArrayLength];

            GetSortedIntegers(sortedIntegers);
            Watch.Restart();
            Sorter<int>.InsertionSort(sortedIntegers);
            Console.WriteLine("Insertion sort of {0} sorted integers takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetSortedIntegers(sortedIntegers);
            Watch.Restart();
            Sorter<int>.SelectionSort(sortedIntegers);
            Console.WriteLine("Selection sort of {0} sorted integers takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetSortedIntegers(sortedIntegers);
            Watch.Restart();
            Sorter<int>.QuickSort(sortedIntegers);
            Console.WriteLine("Quicksort of {0} sorted integers takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);
        }

        private static void PrintRandomIntegersTests()
        {
            int[] randomIntegers = new int[ArrayLength];

            GetRandomIntegers(randomIntegers);
            Watch.Restart();
            Sorter<int>.InsertionSort(randomIntegers);
            Console.WriteLine("Insertion sort of {0} random integers takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetRandomIntegers(randomIntegers);
            Watch.Restart();
            Sorter<int>.SelectionSort(randomIntegers);
            Console.WriteLine("Selection sort of {0} random integers takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetRandomIntegers(randomIntegers);
            Watch.Restart();
            Sorter<int>.QuickSort(randomIntegers);
            Console.WriteLine("Quicksort of {0} random integers takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);
        }

        private static void PrintReversedDoublesTests()
        {
            double[] reversedDoubles = new double[ArrayLength];

            GetReversedDoubles(reversedDoubles);
            Watch.Restart();
            Sorter<double>.InsertionSort(reversedDoubles);
            Console.WriteLine("Insertion sort of {0} reversed doubles takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetReversedDoubles(reversedDoubles);
            Watch.Restart();
            Sorter<double>.SelectionSort(reversedDoubles);
            Console.WriteLine("Selection sort of {0} reversed doubles takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetReversedDoubles(reversedDoubles);
            Watch.Restart();
            Sorter<double>.QuickSort(reversedDoubles);
            Console.WriteLine("Quicksort of {0} reversed doubles takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);
        }

        private static void PrintSortedDoublesTests()
        {
            double[] sortedDoubles = new double[ArrayLength];

            GetSortedDoubles(sortedDoubles);
            Watch.Restart();
            Sorter<double>.InsertionSort(sortedDoubles);
            Console.WriteLine("Insertion sort of {0} sorted doubles takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetSortedDoubles(sortedDoubles);
            Watch.Restart();
            Sorter<double>.SelectionSort(sortedDoubles);
            Console.WriteLine("Selection sort of {0} sorted doubles takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetSortedDoubles(sortedDoubles);
            Watch.Restart();
            Sorter<double>.QuickSort(sortedDoubles);
            Console.WriteLine("Quicksort of {0} sorted doubles takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);
        }

        private static void PrintRandomDoublesTests()
        {
            double[] randomDoubles = new double[ArrayLength];

            GetRandomDoubles(randomDoubles);
            Watch.Restart();
            Sorter<double>.InsertionSort(randomDoubles);
            Console.WriteLine("Insertion sort of {0} random doubles takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetRandomDoubles(randomDoubles);
            Watch.Restart();
            Sorter<double>.SelectionSort(randomDoubles);
            Console.WriteLine("Selection sort of {0} random doubles takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetRandomDoubles(randomDoubles);
            Watch.Restart();
            Sorter<double>.QuickSort(randomDoubles);
            Console.WriteLine("Quicksort of {0} random doubles takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);
        }

        private static void PrintReversedStringsTests()
        {
            string[] reversedStrings = new string[ArrayLength];

            GetReversedStrings(reversedStrings);
            Watch.Restart();
            Sorter<string>.InsertionSort(reversedStrings);
            Console.WriteLine("Insertion sort of {0} reversed strings takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetReversedStrings(reversedStrings);
            Watch.Restart();
            Sorter<string>.SelectionSort(reversedStrings);
            Console.WriteLine("Selection sort of {0} reversed strings takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetReversedStrings(reversedStrings);
            Watch.Restart();
            Sorter<string>.QuickSort(reversedStrings);
            Console.WriteLine("Quicksort of {0} reversed strings takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);
        }

        private static void PrintSortedStringsTests()
        {
            string[] sortedStrings = new string[ArrayLength];

            GetSortedStrings(sortedStrings);
            Watch.Restart();
            Sorter<string>.InsertionSort(sortedStrings);
            Console.WriteLine("Insertion sort of {0} sorted strings takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetSortedStrings(sortedStrings);
            Watch.Restart();
            Sorter<string>.SelectionSort(sortedStrings);
            Console.WriteLine("Selection sort of {0} sorted strings takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetSortedStrings(sortedStrings);
            Watch.Restart();
            Sorter<string>.QuickSort(sortedStrings);
            Console.WriteLine("Quicksort of {0} sorted strings takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);
        }

        private static void PrintRandomStringsTests()
        {
            string[] randomStrings = new string[ArrayLength];

            GetRandomStrings(randomStrings);
            Watch.Restart();
            Sorter<string>.InsertionSort(randomStrings);
            Console.WriteLine("Insertion sort of {0} random strings takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetRandomStrings(randomStrings);
            Watch.Restart();
            Sorter<string>.SelectionSort(randomStrings);
            Console.WriteLine("Selection sort of {0} random strings takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);

            GetRandomStrings(randomStrings);
            Watch.Restart();
            Sorter<string>.QuickSort(randomStrings);
            Console.WriteLine("Quicksort of {0} random strings takes {1} milliseconds.", ArrayLength, Watch.ElapsedMilliseconds);
        }

        private static void GetRandomIntegers(int[] randomIntegers)
        {
            for (int i = 0; i < ArrayLength; i++)
            {
                randomIntegers[i] = RandomGenerator.Next();
            }
        }

        private static void GetSortedIntegers(int[] sortedIntegers)
        {
            for (int i = 0; i < ArrayLength; i++)
            {
                sortedIntegers[i] = i;
            }
        }

        private static void GetReversedIntegers(int[] reversedIntegers)
        {
            for (int i = 0; i < ArrayLength; i++)
            {
                reversedIntegers[ArrayLength - i - 1] = i;
            }
        }

        private static void GetRandomDoubles(double[] randomDoubles)
        {
            for (int i = 0; i < ArrayLength; i++)
            {
                randomDoubles[i] = RandomGenerator.NextDouble();
            }
        }

        private static void GetSortedDoubles(double[] sortedDoubles)
        {
            for (int i = 0; i < ArrayLength; i++)
            {
                sortedDoubles[i] = i;
            }
        }

        private static void GetReversedDoubles(double[] reversedDoubles)
        {
            for (int i = 0; i < ArrayLength; i++)
            {
                reversedDoubles[ArrayLength - i - 1] = i;
            }
        }

        private static void GetRandomStrings(string[] randomStrings)
        {
            for (int i = 0; i < ArrayLength; i++)
            {
                randomStrings[i] = RandomGenerator.Next().ToString();
            }
        }

        private static void GetSortedStrings(string[] sortedStrings)
        {
            for (int i = 0; i < ArrayLength; i++)
            {
                sortedStrings[i] = i.ToString();
            }

            Array.Sort(sortedStrings);
        }

        private static void GetReversedStrings(string[] reversedStrings)
        {
            GetSortedStrings(reversedStrings);
            Array.Reverse(reversedStrings);
        }
    }
}
