using System;

class DayOfWeekToday
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing which day of the week is today***");
        Console.Write(decorationLine);
        DateTime today = DateTime.Today;
        Console.WriteLine("Today is {0}.", today.DayOfWeek);
    }
}
