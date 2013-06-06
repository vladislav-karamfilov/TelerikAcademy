namespace MathOperationsPerformanceComparison
{
    using System;
    using System.Diagnostics;

    public static class NaturalLogarithmTester
    {
        private const int LoopEndCondition = 10000000;

        private static readonly Stopwatch Watch = new Stopwatch();

        public static long TestFloat()
        {
            Watch.Restart();

            for (float i = 0.0f; i < LoopEndCondition; i += 1.0f)
            {
                Math.Log(i);
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestDouble()
        {
            Watch.Restart();

            for (double i = 0.0d; i < LoopEndCondition; i += 1.0d)
            {
                Math.Log(i);
            }

            return Watch.ElapsedMilliseconds;
        }

        public static long TestDecimal()
        {
            Watch.Restart();

            for (decimal i = 0.0m; i < LoopEndCondition; i += 1.0m)
            {
                Math.Log((double)i);
            }

            return Watch.ElapsedMilliseconds;
        }
    }
}
