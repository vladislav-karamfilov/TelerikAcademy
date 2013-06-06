namespace IteratorExample
{
    using System;

    class IteratorExample
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Example for the 'Iterator' design pattern***");
            Console.Write(decorationLine);

            IAggregate<int> fibonacciNumbersToFifty = new Aggregate<int>();
            fibonacciNumbersToFifty.AddItem(0);
            fibonacciNumbersToFifty.AddItem(1);
            fibonacciNumbersToFifty.AddItem(1);
            fibonacciNumbersToFifty.AddItem(2);
            fibonacciNumbersToFifty.AddItem(3);
            fibonacciNumbersToFifty.AddItem(5);
            fibonacciNumbersToFifty.AddItem(8);
            fibonacciNumbersToFifty.AddItem(13);
            fibonacciNumbersToFifty.AddItem(21);
            fibonacciNumbersToFifty.AddItem(34);

            Console.WriteLine("Fibonacci numbers to 50:");
            foreach (int number in fibonacciNumbersToFifty.GetAll())
            {
                Console.WriteLine(number);
            }
        }
    }
}
