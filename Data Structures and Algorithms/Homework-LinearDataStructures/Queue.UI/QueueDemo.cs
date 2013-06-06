using System;
using Queue.Common;

class QueueDemo
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Presenting the functionality of the data structure 'Queue'***");
        Console.Write(decorationLine);

        Queue<string> names = new Queue<string>();

        Console.WriteLine("---Enqueue operation---");
        names.Enqueue("Pesho");
        names.Enqueue("Gosho");
        names.Enqueue("Lili");
        names.Enqueue("Marin");
        names.Enqueue("Elena");
        Console.WriteLine("Count = " + names.Count);
        Console.WriteLine();

        Console.WriteLine("---Iterator functionality---");
        PrintPeopleOnConsole(names);
        Console.WriteLine();

        Console.WriteLine("---Peek operation---");
        string topName = names.Peek();
        Console.WriteLine("Count = " + names.Count);
        Console.WriteLine("The result from peek operation: " + topName);
        Console.WriteLine("Queue after peek:");
        PrintPeopleOnConsole(names);
        Console.WriteLine();

        Console.WriteLine("---Dequeue operation---");
        string poppedName = names.Dequeue();
        Console.WriteLine("The result from dequeue operation: " + poppedName);
        Console.WriteLine("Count = " + names.Count);
        Console.WriteLine("Queue after dequeue:");
        PrintPeopleOnConsole(names);
        Console.WriteLine();

        Console.WriteLine("---Clear operation---");
        names.Clear();
        Console.WriteLine("Elements count after clearing: " + names.Count);
    }

    private static void PrintPeopleOnConsole(Queue<string> people)
    {
        foreach (string person in people)
        {
            Console.WriteLine(person);
        }
    }
}
