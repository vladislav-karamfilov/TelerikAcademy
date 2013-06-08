using System;
using LinkedList.Common;

class LinkedListDemo
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Presenting the functionality of the data structure 'Linked List'***");
        Console.Write(decorationLine);

        LinkedList<string> names = new LinkedList<string>();

        Console.WriteLine("---Add operation---");
        names.Add("Pesho");
        names.Add("Gosho");
        names.Add("Lili");
        names.Add("Marin");
        names.Add("Elena");
        Console.WriteLine("Elements count after adding: " + names.Count);
        Console.WriteLine();

        Console.WriteLine("---Iterator functionality---");
        PrintPeopleOnConsole(names);
        Console.WriteLine();

        Console.WriteLine("---Remove by value operation---");
        names.Remove("Marin");
        Console.WriteLine("Linked list after removal: ");
        PrintPeopleOnConsole(names);
        Console.WriteLine();

        Console.WriteLine("---Remove by index operation---");
        names.RemoveAt(1);
        Console.WriteLine("Linked list after removal: ");
        PrintPeopleOnConsole(names);
        Console.WriteLine();

        Console.WriteLine("---IndexOf operation---");
        Console.WriteLine(names.IndexOf("Elena"));
        Console.WriteLine();

        Console.WriteLine("---Clear operation---");
        names.Clear();
        Console.WriteLine("Elements count after clearing: " + names.Count);
    }

    private static void PrintPeopleOnConsole(LinkedList<string> people)
    {
        foreach (string person in people)
        {
            Console.WriteLine(person);
        }
    }
}
