using System;

class CheckForLeapYear
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Checking if a year is leap or not***");
        Console.Write(decorationLine);
        Console.Write("Enter the year to check: ");
        int year = int.Parse(Console.ReadLine());
        bool isLeapYear = DateTime.IsLeapYear(year);
        if (isLeapYear)
        {
            Console.WriteLine("The year {0} is leap.", year);
        }
        else
        {
            Console.WriteLine("The year {0} is not leap.", year);
        }
    }
}
