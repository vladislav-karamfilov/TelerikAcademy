namespace NumericalTypesPerformanceComparison
{
    using System;
    using System.Diagnostics;

    public static class DivisionPerformanceTester
    {
        private const int LoopEndCondition = 1000000;
        private const int IntDivisor = 1;
        private const long LongDivisor = 1L;
        private const float FloatDivisor = 1.0f;
        private const double DoubleDivisor = 1.0d;
        private const decimal DecimalDivisor = 1.0m;

        private static readonly Stopwatch Watch = new Stopwatch();

        public static long TestInteger()
        {
            int quotient = 1;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                quotient /= IntDivisor;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestLong()
        {
            long quotient = 1L;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                quotient /= LongDivisor;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestFloat()
        {
            float quotient = 1.0f;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                quotient /= FloatDivisor;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestDouble()
        {
            double quotient = 1.0d;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                quotient /= DoubleDivisor;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestDecimal()
        {
            decimal quotient = 1.0m;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                quotient /= DecimalDivisor;
            }

            return Watch.ElapsedMilliseconds;
        }
    }
}
