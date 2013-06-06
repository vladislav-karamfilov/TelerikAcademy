using System;

class NotDivisibleByThreeAndSevenNumbers
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing all the numbers from 1 to N that are not\ndivisible by 3 and 7 at the same time***");
        Console.Write(decorationLine);
        Console.Write("Enter N: ");
        uint n;
        while (!uint.TryParse(Console.ReadLine(), out n) || n == 0)
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter N: ");
        }
        uint number = 0;
        do
        {
            number++;
            if (number % 21 == 0) 
            {
                continue;
            }
            Console.Write(number + "\t\t");
        } while (number < n);
        Console.WriteLine();
    }
}
