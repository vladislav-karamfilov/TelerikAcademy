using System;

class TestDivisionByFiveAndSeven
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Testing if an integer ca be divided without\nremainder by 5 and 7 in the same time***");
        Console.Write(decorationLine);
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        // If the number can be divided by 5 and 7 in the same time, it can be divided by 35
        bool checkDivision = (number % 35 == 0);
        if (checkDivision == true)
        {
            Console.WriteLine("The number can be divided without remainder by 5 and 7 in the same time.");
        }
        else
        {
            Console.WriteLine("The number cannot be divided without remainder by 5 and 7 in the same time.");
        }
    }
}
