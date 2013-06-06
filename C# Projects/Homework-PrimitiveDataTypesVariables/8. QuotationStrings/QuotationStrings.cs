using System;

class QuotationStrings
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Declaring two strings and assigning them with a value without\nusing quoted string and using quoted string***");
        Console.Write(decorationLine);
        string nonQuotedString = "The \"use\" of quotations causes difficulties.";
        string quotedString = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine("Both are the same:\n{0}\n{1}", nonQuotedString, quotedString);
    }
}
