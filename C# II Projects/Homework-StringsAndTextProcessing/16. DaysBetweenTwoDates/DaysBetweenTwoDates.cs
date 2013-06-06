using System;
using System.Globalization;

class DaysBetweenTwoDates
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the days between two dates given in format 'day.month.year'***");
        Console.Write(decorationLine);
        Console.Write("Enter the first date in the format described: ");
        DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);
        Console.Write("Enter the second date in the format described: ");
        DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);
        TimeSpan daysBetween = secondDate.Subtract(firstDate);
        Console.WriteLine("The days between are {0}.", daysBetween.Days);
    }
}
