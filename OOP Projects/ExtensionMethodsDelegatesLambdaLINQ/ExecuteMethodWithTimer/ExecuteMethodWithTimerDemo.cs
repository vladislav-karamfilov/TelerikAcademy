using System;

namespace ExecuteMethodWithTimer
{
    class ExecuteMethodWithTimerDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Executing a certain method at each 'T' seconds***");
            Console.Write(decorationLine);

            Console.Write("Enter in how many seconds T to re-call the method: ");
            int intervalInSeconds = int.Parse(Console.ReadLine());
            Console.Write("Enter how many times to call the method: ");
            int cycles = int.Parse(Console.ReadLine());

            Timer timer = new Timer(TestMethod);
            timer.Run(intervalInSeconds, cycles);
        }

        static void TestMethod()
        {
            Console.WriteLine("I'm called at {0}.", DateTime.Now.ToLongTimeString());
        }
    }
}
