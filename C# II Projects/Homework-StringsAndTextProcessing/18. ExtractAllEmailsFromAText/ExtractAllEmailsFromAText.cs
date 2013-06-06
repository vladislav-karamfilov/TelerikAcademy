using System;
using System.Text.RegularExpressions;

class ExtractAllEmailsFromAText
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Extracting all email addresses from a text***");
        Console.Write(decorationLine);
        Console.Write("Enter the text: ");
        string text = Console.ReadLine();
        string emailRegex = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        Match match = Regex.Match(text, emailRegex);
        Console.WriteLine("The emails from the text are: ");
        while (match.Success)
        {
            Console.WriteLine(match);
            match = match.NextMatch();
        }
    }
}
