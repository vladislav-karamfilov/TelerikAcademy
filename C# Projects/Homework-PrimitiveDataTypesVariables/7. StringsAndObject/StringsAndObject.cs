using System;

class StringsAndObject
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Declaring two strings, assigning them, assigning their concatenation\nto \"object\" variable and assigning it to third string***");
        Console.Write(decorationLine);
        string greeting = "Hello";
        string addressee = "World";
        object fullGreeting = greeting + ", " + addressee + "!";
        string stringFullGreeting = (string)fullGreeting;
        Console.WriteLine(stringFullGreeting);
    }
}