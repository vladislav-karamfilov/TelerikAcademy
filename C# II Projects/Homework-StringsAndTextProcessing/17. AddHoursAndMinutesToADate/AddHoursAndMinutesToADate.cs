using System;
using System.Globalization;
using System.Text;

class AddHoursAndMinutesToADate
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo cultureBulgarian = new CultureInfo("bg-BG");
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Reading a date in format 'day.month.year hour:minute:second' and adding \n6 hours and 30 minutes***");
        Console.Write(decorationLine);
        Console.Write("Enter the date in the format described: ");
        string dateInput = Console.ReadLine();
        DateTime date = DateTime.ParseExact(dateInput, "d.M.yyyy HH:mm:ss", cultureBulgarian);
        date = date.AddHours(6.5);
        string dayOfWeekInBulgarian = date.ToString("dddd", cultureBulgarian);
        Console.WriteLine("After 6 hours and 30 minutes -> {0:dd.MM.yyyy HH:mm:ss}", date);
        Console.WriteLine("The day of the week in Bulgarian is '{0}'.", dayOfWeekInBulgarian);
    }
}
