using System;

namespace ExecuteMethodWithTimerEvent
{
    class ExecuteMethodWithTimerEventDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Executing a certain method at each 'T' seconds***");
            Console.Write(decorationLine);

            Console.Write("Enter in how many seconds to re-call the method: ");
            int intervalInSeconds = int.Parse(Console.ReadLine());
            Console.Write("Enter how many times to call the method: ");
            int cycles = int.Parse(Console.ReadLine());

            Timer timer = new Timer(intervalInSeconds, cycles);
            timer.TimeElapsed += TestMethod; // Subscribing for the time elapsed event in Timer
            timer.Run(); // Calling the method that raises the event
        }

        static void TestMethod(object sender, TimeElapsedEventArgs eventArgs)
        {
            Console.WriteLine("I'm a method sent by a '{0}' object and called at {1}.", 
                sender.GetType().Name, eventArgs.DateTimeNow.ToLongTimeString());
        }
    }
}
