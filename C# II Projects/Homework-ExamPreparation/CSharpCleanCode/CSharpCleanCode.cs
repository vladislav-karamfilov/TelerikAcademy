using System;
using System.Text;

class CSharpCleanCode
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        bool inMultiLineComment = false;
        bool inVerbatimString = false;
        StringBuilder withoutComments = new StringBuilder();
        for (int line = 0; line < lines; line++)
        {
            string currentLine = Console.ReadLine();
            StringBuilder currentNewLine = new StringBuilder();
            int lengthOfLine = currentLine.Length;
            bool inString = false;
            bool inSingleLineComment = false;
            for (int index = 0; index < lengthOfLine; index++)
            {
                if (!inMultiLineComment && !inSingleLineComment)
                {
                    if (!inString && !inVerbatimString)
                    {
                        if (currentLine[index] == '@' && index + 1 < lengthOfLine && currentLine[index + 1] == '\"')
                        {
                            inVerbatimString = true;
                            currentNewLine.Append(currentLine[index]);
                            index++;
                            currentNewLine.Append(currentLine[index]);
                            continue;
                        }
                        if (currentLine[index] == '\"')
                        {
                            inString = true;
                            currentNewLine.Append(currentLine[index]);
                            continue;
                        }
                    }
                }
                if (!inSingleLineComment && !inMultiLineComment && !inString && !inVerbatimString &&
                    currentLine[index] == '/' && index + 1 < lengthOfLine && currentLine[index + 1] == '/')
                {
                    if (index + 2 < lengthOfLine && currentLine[index + 2] == '/')
                    {
                        currentNewLine.Append("///");
                        index += 2;
                        continue;
                    }
                    inSingleLineComment = true;
                    index++;
                }
                if (!inSingleLineComment && !inMultiLineComment && !inString && !inVerbatimString &&
                    currentLine[index] == '/' && index + 1 < lengthOfLine && currentLine[index + 1] == '*')
                {
                    inMultiLineComment = true;
                    index++;
                }
                if (inString && currentLine[index] == '\"' && currentLine[index - 1] != '\\')
                {
                    inString = false;
                }
                if (inVerbatimString && index > 0 && currentLine[index] == '\"' && currentLine[index - 1] != '\"')
                {
                    inVerbatimString = false;
                    currentNewLine.Append(currentLine[index]);
                    continue;
                }
                if (inMultiLineComment && currentLine[index] == '/' && currentLine[index - 1] == '*')
                {
                    inMultiLineComment = false;
                    continue;
                }
                if (!inMultiLineComment && !inSingleLineComment)
                {
                    currentNewLine.Append(currentLine[index]);
                }
            }
            if (!inMultiLineComment)
            {
                currentNewLine.AppendLine();
            }
            if (currentNewLine.ToString().TrimStart().Length != 0)
            {
                withoutComments.Append(currentNewLine);
            }
        }
        Console.Write(withoutComments);
    }
}