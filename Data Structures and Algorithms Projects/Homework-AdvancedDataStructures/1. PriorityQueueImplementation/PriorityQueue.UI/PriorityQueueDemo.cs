using System;
using PriorityQueue.Common;

namespace PriorityQueue.UI
{
    class PriorityQueueDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Presenting the functionality of the data structure 'Priority queue'***");
            Console.Write(decorationLine);

            PriorityQueue<int> numbers = new PriorityQueue<int>();

            Console.WriteLine("---Enqueue operation---");
            numbers.Enqueue(4);
            numbers.Enqueue(-1);
            numbers.Enqueue(3);
            numbers.Enqueue(22);
            numbers.Enqueue(16);
            numbers.Enqueue(-9);
            numbers.Enqueue(10);
            numbers.Enqueue(14);
            numbers.Enqueue(-48);
            numbers.Enqueue(71);
            Console.WriteLine("Count = " + numbers.Count);
            Console.WriteLine();

            Console.WriteLine("---Iterator functionality---");
            PrintNumbersOnConsole(numbers);
            Console.WriteLine();

            Console.WriteLine("---Peek operation---");
            int topNumber = numbers.Peek();
            Console.WriteLine("Count = " + numbers.Count);
            Console.WriteLine("The result from peek operation: " + topNumber);
            Console.WriteLine("Queue after peek:");
            PrintNumbersOnConsole(numbers);
            Console.WriteLine();

            Console.WriteLine("---Dequeue operation---");
            int poppedNumber = numbers.Dequeue();
            Console.WriteLine("The result from dequeue operation: " + poppedNumber);
            Console.WriteLine("Count = " + numbers.Count);
            Console.WriteLine("Queue after dequeue:");
            PrintNumbersOnConsole(numbers);
            Console.WriteLine();

            Console.WriteLine("---Clear operation---");
            numbers.Clear();
            Console.WriteLine("Elements count after clearing: " + numbers.Count);
        }

        private static void PrintNumbersOnConsole(PriorityQueue<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
