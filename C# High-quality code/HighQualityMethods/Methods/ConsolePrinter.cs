namespace Methods
{
    using System;

    public static class ConsolePrinter
    {
        public static void PrintNumber(double number, int decimals)
        {
            Console.WriteLine("{0:f" + decimals + "}", number);
        }

        public static void PrintPercent(double number, int decimals)
        {
            Console.WriteLine("{0:P" + decimals + "}", number);
        }

        public static void PrintAligned(object value, int totalWidth)
        {
            Console.WriteLine("{0," + totalWidth + "}", value);
        }
    }
}