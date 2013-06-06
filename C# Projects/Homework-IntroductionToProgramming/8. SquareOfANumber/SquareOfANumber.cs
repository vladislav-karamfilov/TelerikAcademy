using System;

class SquareOfANumber
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing the square of the number 12345***");
        Console.Write(decorationLine);
        Console.WriteLine("The square of {0} is {1}.", 12345, 12345 * 12345);
    }
}

