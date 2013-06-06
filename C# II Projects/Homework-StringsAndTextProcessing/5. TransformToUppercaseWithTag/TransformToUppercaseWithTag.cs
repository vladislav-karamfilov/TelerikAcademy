using System;

class TransformToUppercaseWithTag
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Changing all text between tags <upcase> and </upcase> to uppercase***");
        Console.Write(decorationLine);
        Console.Write("Enter the text to transform: ");
        string text = Console.ReadLine();
        int startTagIndex = 0;
        int endTagIndex = 0;
        while (true)
        {
            startTagIndex = text.IndexOf("<upcase>", Math.Max(startTagIndex, endTagIndex));
            endTagIndex = text.IndexOf("</upcase>", Math.Max(startTagIndex, endTagIndex));
            if (startTagIndex != -1 && endTagIndex != -1)
            {
                // Covers the case when the tags are not correctly put
                if (startTagIndex < endTagIndex)
                {
                    string substring = text.Substring(startTagIndex + 8, endTagIndex - startTagIndex - 8);
                    text = text.Replace("<upcase>" + substring + "</upcase>", substring.ToUpper());
                    startTagIndex -= 8;
                    endTagIndex -= 9;
                    if (startTagIndex < 0 || endTagIndex < 0)
                    {
                        break;
                    }
                }
                continue;
            }
            break;
        }
        Console.WriteLine("The transformed text is: " + text);
    }
}
