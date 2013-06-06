using System;

class MinAndMaxOfASequenceOfIntegers
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Entering N integers and finding the minimal and maximal of them***");
        Console.Write(decorationLine);
        Console.Write("Enter how many integers N you will enter: ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter N: ");
        }
        int maxNumber = int.MinValue;
        int minNumber = int.MaxValue;
        int number;
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter an integer: ");
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input! Try again...");
                Console.Write("Enter an integer: ");
            }
            if (number > maxNumber)
            {
                maxNumber = number;
            }
            if (number < minNumber)
            {
                minNumber = number;
            }
        }
        Console.WriteLine("The minimal integer of all is {0} and the maximal is {1}.", minNumber, maxNumber);
    }
}
