using System;

class CountSubstringOccurrences
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Counting how many times a substring is contained in a text \n(case insensitive search)***");
        Console.Write(decorationLine);
        Console.Write("Enter the text: ");
        string text = Console.ReadLine();
        Console.Write("Enter the substring: ");
        string substring = Console.ReadLine();
        int occurrences = 0;
        int startIndex = -1;
        while (true)
        {
            startIndex = text.IndexOf(substring, startIndex + 1, StringComparison.CurrentCultureIgnoreCase);
            if (startIndex == -1)
            {
                break;
            }
            occurrences++;
        }
        Console.WriteLine("The substring '{0}' is contained {1} times.", substring, occurrences);
    }
}
