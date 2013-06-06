using System;

class CurrentDateAndTime
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing the current date and time***");
        Console.Write(decorationLine);
        DateTime currentDateTime = DateTime.Now;
        Console.WriteLine("Current date and time: " + currentDateTime + ".");
    }
}