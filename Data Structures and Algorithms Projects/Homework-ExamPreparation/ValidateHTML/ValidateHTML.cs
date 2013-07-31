using System;
using System.Collections.Generic;
using System.Text;

class ValidateHTML
{
    static void Main()
    {
        int htmlLinesCount = int.Parse(Console.ReadLine());
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < htmlLinesCount; i++)
        {
            output.AppendLine(Validate(Console.ReadLine()));
        }

        Console.Write(output);
    }

    static string Validate(string htmlLine)
    {
        Stack<string> openedTags = new Stack<string>();   
        
        bool inOpenTag = false;
        bool inCloseTag = false;
        StringBuilder currentTag = new StringBuilder();
        for (int i = 0; i < htmlLine.Length; i++)
        {
            if (htmlLine[i] == '<')
            {
                if (i + 1 < htmlLine.Length && htmlLine[i + 1] != '/')
                {
                    inOpenTag = true;
                }
                else
                {
                    i++;
                    inCloseTag = true;
                }
            }
            else if (htmlLine[i] == '>')
            {
                if (inOpenTag)
                {
                    openedTags.Push(currentTag.ToString());
                }
                else if (inCloseTag)
                {
                    if (openedTags.Count > 0)
                    {
                        if (openedTags.Pop() != currentTag.ToString())
                        {
                            return "INVALID";
                        }
                    }
                    else
                    {
                        return "INVALID";
                    }
                }

                currentTag.Clear();
                inOpenTag = false;
                inCloseTag = false;
            }
            else
            {
                currentTag.Append(htmlLine[i]);
            }
        }

        return openedTags.Count == 0 ? "VALID" : "INVALID";
    }
}
