namespace NumericalTypesPerformanceComparison
{
    using System;

    public class NumericalTypesPerformanceComparison
    {
        public static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Comparing the performance of add, subtract, multiply and divide for int,");
            Console.WriteLine("long, float, double and decimal values***");
            Console.Write(decorationLine);

            PrintAdditionTests();
            Console.WriteLine();

            PrintSubtractionTests();
            Console.WriteLine();

            PrintIncrementationTests();
            Console.WriteLine();

            PrintMultiplicationTests();
            Console.WriteLine();

            PrintDivisionTests();
        }

        private static void PrintAdditionTests()
        {
            Console.WriteLine("Addition test for integer values takes {0} milliseconds.", AdditionPerformanceTester.TestInteger());
            Console.WriteLine("Addition test for long values takes {0} milliseconds.", AdditionPerformanceTester.TestLong());
            Console.WriteLine("Addition test for float values takes {0} milliseconds.", AdditionPerformanceTester.TestFloat());
            Console.WriteLine("Addition test for double values takes {0} milliseconds.", AdditionPerformanceTester.TestDouble());
            Console.WriteLine("Addition test for decimal values takes {0} milliseconds.", AdditionPerformanceTester.TestDecimal());
        }

        private static void PrintSubtractionTests()
        {
            Console.WriteLine("Subtraction test for integer values takes {0} milliseconds.", SubtractionPerformanceTester.TestInteger());
            Console.WriteLine("Subtraction test for long values takes {0} milliseconds.", SubtractionPerformanceTester.TestLong());
            Console.WriteLine("Subtraction test for float values takes {0} milliseconds.", SubtractionPerformanceTester.TestFloat());
            Console.WriteLine("Subtraction test for double values takes {0} milliseconds.", SubtractionPerformanceTester.TestDouble());
            Console.WriteLine("Subtraction test for decimal values takes {0} milliseconds.", SubtractionPerformanceTester.TestDecimal());
        }

        private static void PrintIncrementationTests()
        {
            Console.WriteLine("Incrementation test for integer values takes {0} milliseconds.", IncrementationPerformanceTester.TestInteger());
            Console.WriteLine("Incrementation test for long values takes {0} milliseconds.", IncrementationPerformanceTester.TestLong());
            Console.WriteLine("Incrementation test for float values takes {0} milliseconds.", IncrementationPerformanceTester.TestFloat());
            Console.WriteLine("Incrementation test for double values takes {0} milliseconds.", IncrementationPerformanceTester.TestDouble());
            Console.WriteLine("Incrementation test for decimal values takes {0} milliseconds.", IncrementationPerformanceTester.TestDecimal());
        }

        private static void PrintMultiplicationTests()
        {
            Console.WriteLine("Multiplication test for integer values takes {0} milliseconds.", MultiplicationPerformanceTester.TestInteger());
            Console.WriteLine("Multiplication test for long values takes {0} milliseconds.", MultiplicationPerformanceTester.TestLong());
            Console.WriteLine("Multiplication test for float values takes {0} milliseconds.", MultiplicationPerformanceTester.TestFloat());
            Console.WriteLine("Multiplication test for double values takes {0} milliseconds.", MultiplicationPerformanceTester.TestDouble());
            Console.WriteLine("Multiplication test for decimal values takes {0} milliseconds.", MultiplicationPerformanceTester.TestDecimal());
        }

        private static void PrintDivisionTests()
        {
            Console.WriteLine("Division test for integer values takes {0} milliseconds.", DivisionPerformanceTester.TestInteger());
            Console.WriteLine("Division test for long values takes {0} milliseconds.", DivisionPerformanceTester.TestLong());
            Console.WriteLine("Division test for float values takes {0} milliseconds.", DivisionPerformanceTester.TestFloat());
            Console.WriteLine("Division test for double values takes {0} milliseconds.", DivisionPerformanceTester.TestDouble());
            Console.WriteLine("Division test for decimal values takes {0} milliseconds.", DivisionPerformanceTester.TestDecimal());
        }
    }
}
