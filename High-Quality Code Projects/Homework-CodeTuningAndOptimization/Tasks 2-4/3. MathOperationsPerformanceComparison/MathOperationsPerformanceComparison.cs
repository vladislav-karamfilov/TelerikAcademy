using System;

namespace MathOperationsPerformanceComparison
{
    public class MathOperationsPerformanceComparison
    {
        public static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Comparing the performance of square root, natural logarithm and sinus");
            Console.WriteLine("for float, double and decimal***");
            Console.Write(decorationLine);

            PrintSquareRootTests();
            Console.WriteLine();

            PrintNaturalLogarithmTests();
            Console.WriteLine();

            PrintSinusTests();
        }

        private static void PrintSquareRootTests()
        {
            Console.WriteLine("Calculating square root with float values takes {0} milliseconds.", SquareRootTester.TestFloat());
            Console.WriteLine("Calculating square root with double values takes {0} milliseconds.", SquareRootTester.TestDouble());
            Console.WriteLine("Calculating square root with decimal values takes {0} milliseconds.", SquareRootTester.TestDecimal());
        }

        private static void PrintNaturalLogarithmTests()
        {
            Console.WriteLine("Calculating natural logarithm with float values takes {0} milliseconds.", NaturalLogarithmTester.TestFloat());
            Console.WriteLine("Calculating natural logarithm with double values takes {0} milliseconds.", NaturalLogarithmTester.TestDouble());
            Console.WriteLine("Calculating natural logarithm with decimal values takes {0} milliseconds.", NaturalLogarithmTester.TestDecimal());
        }

        private static void PrintSinusTests()
        {
            Console.WriteLine("Calculating sinus with float values takes {0} milliseconds.", SinusTester.TestFloat());
            Console.WriteLine("Calculating sinus with double values takes {0} milliseconds.", SinusTester.TestDouble());
            Console.WriteLine("Calculating sinus with decimal values takes {0} milliseconds.", SinusTester.TestDecimal());
        }
    }
}
