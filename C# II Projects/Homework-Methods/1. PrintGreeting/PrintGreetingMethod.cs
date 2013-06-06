using System;

class PrintGreetingMethod
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing a greeting according to a name***");
        Console.Write(decorationLine);
        Console.Write("Enter a name: ");
        string name = Console.ReadLine();
        PrintGreeting(name);
    }

    static void PrintGreeting(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }
}
