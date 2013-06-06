namespace NumericalTypesPerformanceComparison
{
    using System;
    using System.Diagnostics;

    public static class MultiplicationPerformanceTester
    {
        private const int LoopEndCondition = 1000000;
        private const int IntMultiplier = 1;
        private const long LongMultiplier = 1L;
        private const float FloatMultiplier = 1.0f;
        private const double DoubleMultiplier = 1.0d;
        private const decimal DecimalMultiplier = 1.0m;

        private static readonly Stopwatch Watch = new Stopwatch();

        public static long TestInteger()
        {
            int product = 1;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                product *= IntMultiplier;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestLong()
        {
            long product = 1L;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                product *= LongMultiplier;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestFloat()
        {
            float product = 1.0f;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                product *= FloatMultiplier;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestDouble()
        {
            double product = 1.0d;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                product *= DoubleMultiplier;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestDecimal()
        {
            decimal product = 1.0m;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                product *= DecimalMultiplier;
            }

            return Watch.ElapsedMilliseconds;
        }
    }
}
