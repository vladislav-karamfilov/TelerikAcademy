namespace NumericalTypesPerformanceComparison
{
    using System;
    using System.Diagnostics;

    public static class IncrementationPerformanceTester
    {
        private const int LoopEndCondition = 1000000;

        private static readonly Stopwatch Watch = new Stopwatch();

        public static long TestInteger()
        {
            int incrementationResult = 0;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                incrementationResult++;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestLong()
        {
            long incrementationResult = 0L;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                incrementationResult++;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestFloat()
        {
            float incrementationResult = 0.0f;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                incrementationResult++;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestDouble()
        {
            double incrementationResult = 0.0d;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                incrementationResult++;
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestDecimal()
        {
            decimal incrementationResult = 0.0m;

            Watch.Restart();

            for (int i = 0; i < LoopEndCondition; i++)
            {
                incrementationResult++;
            }

            return Watch.ElapsedMilliseconds;
        }
    }
}
