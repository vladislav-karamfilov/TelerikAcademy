using System;

class AllTheNumbersFromOneToN
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing all the numbers from 1 to N***");
        Console.Write(decorationLine);
        Console.Write("Enter N: ");
        uint n;
        while (!uint.TryParse(Console.ReadLine(), out n) || n == 0)
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter N: ");
        }
        uint number = 1U;
        while (number <= n)
        {
            Console.Write("{0}\t\t", number);
            number++;
        }
        Console.WriteLine();
    }
}
