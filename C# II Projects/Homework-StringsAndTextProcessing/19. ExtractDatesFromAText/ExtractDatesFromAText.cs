using System;
using System.Text.RegularExpressions;
using System.Globalization;

class ExtractDatesFromAText
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Extracting all dates in format DD.MM.YYYY from a text***");
        Console.Write(decorationLine);
        Console.Write("Enter the text to extract dates: ");
        string text = Console.ReadLine();
        string dateRegex = "\\b[0-9]{2}.[0-9]{2}.[0-9]{4}\\b";
        Match match = Regex.Match(text, dateRegex);
        DateTime date = new DateTime();
        Console.WriteLine("All the dates from the text in Canadian date format are: ");
        while (match.Success)
        {
            if (DateTime.TryParseExact(match.Value, "dd.MM.yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out date))
            {
                string dateCanada = date.ToShortDateString().ToString(new CultureInfo("en-CA"));
                Console.WriteLine("The date in format for Canada: " + dateCanada);
            }
            match = match.NextMatch();
        }
    }
}
