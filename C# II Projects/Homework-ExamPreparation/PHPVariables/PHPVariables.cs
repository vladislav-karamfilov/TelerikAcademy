using System;
using System.Collections.Generic;
using System.Text;

class PHPVariables
{
    static List<string> variables = new List<string>();
    static bool inMultilineComment = false;

    static void Main()
    {
        string inputLine = Console.ReadLine();
        while (true)
        {
            inputLine = Console.ReadLine().Trim();
            if (inputLine == "?>")
            {
                break;
            }
            CheckLineForVariables(inputLine);
        }
        variables.Sort(StringComparer.Ordinal);
        Console.WriteLine(variables.Count);
        foreach (string variable in variables)
        {
            Console.WriteLine(variable);
        }
    }

    static void CheckLineForVariables(string inputLine)
    {
        bool inSingleLineComment = false;
        bool inSingleQuotedString = false;
        bool inDoubleQuotedString = false;
        bool inVariable = false;
        StringBuilder variable = new StringBuilder();
        for (int i = 0; i < inputLine.Length; i++)
        {
            // States for in/out of comments
            if (!inSingleQuotedString && !inDoubleQuotedString)
            {
                if (inputLine[i] == '#' || (inputLine[i] == '/' && i + 1 < inputLine.Length && inputLine[i + 1] == '/'))
                {
                    inSingleLineComment = true;
                    i++;
                    continue;
                }
                if (inputLine[i] == '/' && i + 1 < inputLine.Length && inputLine[i + 1] == '*')
                {
                    inMultilineComment = true;
                    i++;
                    continue;
                }
                if (inputLine[i] == '*' && i + 1 < inputLine.Length && inputLine[i + 1] == '/')
                {
                    inMultilineComment = false;
                    i++;
                    continue;
                }
            }
            // States for in/out of strings
            if (!inSingleLineComment && !inMultilineComment)
            {
                if (!inSingleQuotedString && !inDoubleQuotedString && inputLine[i] == '\'')
                {
                    inSingleQuotedString = true;
                    continue;
                }
                if (!inDoubleQuotedString && !inSingleQuotedString && inputLine[i] == '\"')
                {
                    inDoubleQuotedString = true;
                    continue;
                }
                if (inDoubleQuotedString && inputLine[i] == '\\')
                {
                    if (i + 1 < inputLine.Length && (inputLine[i + 1] == '$' || inputLine[i + 1] == '\\' || inputLine[i + 1] == '\"'))
                    {
                        i += 2;
                        continue;
                    }
                }
                if (inSingleQuotedString && inputLine[i] == '\\')
                {
                    if (i + 1 < inputLine.Length && (inputLine[i + 1] == '$' || inputLine[i + 1] == '\\' || inputLine[i + 1] == '\''))
                    {
                        i++;
                        continue;
                    }
                }
                if ((inDoubleQuotedString || inSingleQuotedString) && inputLine[i] == '$')
                {
                    inVariable = true;
                    i++;
                }
                if (inDoubleQuotedString && inputLine[i] == '\"' && i > 0 && inputLine[i - 1] != '\\')
                {
                    inDoubleQuotedString = false;
                    continue;
                }
                if (inSingleQuotedString && inputLine[i] == '\'' && i > 0 && inputLine[i - 1] != '\\')
                {
                    inSingleQuotedString = false;
                    continue;
                }
            }
            // States for in/out of variable
            if (!inSingleLineComment && !inSingleQuotedString && !inMultilineComment &&
                !inDoubleQuotedString && inputLine[i] == '$')
            {
                inVariable = true;
                i++;
            }
            if (inVariable)
            {
                if (i < inputLine.Length && (char.IsLetterOrDigit(inputLine[i]) || inputLine[i] == '_'))
                {
                    variable.Append(inputLine[i]);
                }
                else
                {
                    if (!variables.Contains(variable.ToString()))
                    {
                        variables.Add(variable.ToString());
                    }
                    variable.Clear();
                    inVariable = false;
                }
            }
        }
    }
}
