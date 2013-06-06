using System;

class OddOrEvenInteger
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Checking if an integer is even or odd***");
        Console.Write(decorationLine);
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine((number % 2 == 0) ? "The number is even." : "The number is odd.");
    }
}
