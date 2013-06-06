using System;
using System.Text;

class CSharpBrackets
{
    static void Main()
    {
        int linesCount = int.Parse(Console.ReadLine());
        string indentation = Console.ReadLine();
        StringBuilder tempFormatted = new StringBuilder();
        StringBuilder currentContent = new StringBuilder();
        int indentationsCount = 0;
        for (int i = 0; i < linesCount; i++)
        {
            string currentLine = Console.ReadLine().Trim();
            for (int j = 0; j < currentLine.Length; j++)
            {
                if (currentLine[j] == '{')
                {
                    tempFormatted.Append(currentContent.ToString().Trim());
                    currentContent = new StringBuilder();
                    tempFormatted.AppendLine();
                    tempFormatted.Append(AddIndentations(indentation, indentationsCount));
                    tempFormatted.AppendLine("{");
                    indentationsCount++;
                }
                else if (currentLine[j] == '}')
                {
                    tempFormatted.Append(currentContent.ToString().Trim());
                    currentContent = new StringBuilder();
                    tempFormatted.AppendLine();
                    indentationsCount--;
                    tempFormatted.Append(AddIndentations(indentation, indentationsCount));
                    tempFormatted.AppendLine("}");
                }
                else
                {
                    if (tempFormatted.Length > 0 && tempFormatted[tempFormatted.Length - 1] == '\n')
                    {
                        tempFormatted.Append(AddIndentations(indentation, indentationsCount));
                    }
                    if (currentContent.Length > 0 && currentContent[currentContent.Length - 1] == ' ' && currentLine[j] == ' ')
                    {
                        continue;
                    }
                    currentContent.Append(currentLine[j]);    
                }
            }
            tempFormatted.Append(currentContent.ToString().Trim());
            currentContent = new StringBuilder();
            tempFormatted.AppendLine();
        }
        Console.WriteLine(GetFormattedCode(tempFormatted.ToString()));
    }

    static string GetFormattedCode(string tempFormatted)
    {
        StringBuilder formatted = new StringBuilder();
        string[] splittedTempFormatted = tempFormatted.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < splittedTempFormatted.Length; i++)
        {
            formatted.AppendLine(splittedTempFormatted[i]);
        }
        formatted.Length--;
        return formatted.ToString();
    }

    static string AddIndentations(string indentation, int count)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            result.Append(indentation);
        }
        return result.ToString();
    }
}
