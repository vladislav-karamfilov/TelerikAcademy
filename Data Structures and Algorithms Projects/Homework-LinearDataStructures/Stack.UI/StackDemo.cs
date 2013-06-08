using System;
using Stack.Common;

class StackDemo
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Presenting the functionality of the data structure 'Stack'***");
        Console.Write(decorationLine);

        Stack<string> names = new Stack<string>();

        Console.WriteLine("---Push operation---");
        names.Push("Pesho");
        names.Push("Gosho");
        names.Push("Lili");
        names.Push("Marin");
        names.Push("Elena");
        Console.WriteLine("Count = " + names.Count);
        Console.WriteLine();

        Console.WriteLine("---Iterator functionality---");
        PrintPeopleOnConsole(names);
        Console.WriteLine();

        Console.WriteLine("---Peek operation---");
        string topName = names.Peek();
        Console.WriteLine("Count = " + names.Count);
        Console.WriteLine("The result from peek operation: " + topName);
        Console.WriteLine("Stack after peek:");
        PrintPeopleOnConsole(names);
        Console.WriteLine();

        Console.WriteLine("---Pop operation---");
        string poppedName = names.Pop();
        Console.WriteLine("The result from pop operation: " + poppedName);
        Console.WriteLine("Count = " + names.Count);
        Console.WriteLine("Stack after peek:");
        PrintPeopleOnConsole(names);
        Console.WriteLine();

        Console.WriteLine("---Clear operation---");
        names.Clear();
        Console.WriteLine("Elements count after clearing: " + names.Count);
    }

    private static void PrintPeopleOnConsole(Stack<string> people)
    {
        foreach (string person in people)
        {
            Console.WriteLine(person);
        }
    }
}
