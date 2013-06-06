using System;

class MyFirstAndLastNames
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing my first and last names***");
        Console.Write(decorationLine);
        string firstName = "Vladislav";
        string lastName = "Karamfilov";
        Console.WriteLine("My full name is " + firstName + " " + lastName + ".");
    }
}