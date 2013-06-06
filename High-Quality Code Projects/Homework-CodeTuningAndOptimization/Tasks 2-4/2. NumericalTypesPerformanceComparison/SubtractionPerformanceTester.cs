namespace NumericalTypesPerformanceComparison
{
    using System;
    using System.Diagnostics;

    public static class SubtractionPerformanceTester
    {
        private const int LoopEndCondition = 1000000;
        private const int IntStep = 5;
        private const long LongStep = 5L;
        private const float FloatStep = 5.0f;
        private const double DoubleStep = 5.0d;
        private const decimal DecimalStep = 5.0m;

        private static readonly Stopwatch Watch = new Stopwatch();

        public static long TestInteger()
        {
            int difference = 0;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                difference -= IntStep;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestLong()
        {
            long difference = 0L;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                difference -= LongStep;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestFloat()
        {
            float difference = 0.0f;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                difference -= FloatStep;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestDouble()
        {
            double difference = 0.0d;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                difference -= DoubleStep;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestDecimal()
        {
            decimal difference = 0.0m;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                difference -= DecimalStep;
            }

            return Watch.ElapsedMilliseconds;
        }
    }
}
