using System;
using System.IO;
using System.Text;

class DeleteOddLinesInAFile
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Deleting all odd lines from a text file***");
        Console.Write(decorationLine);
        // The used file is in bin\Debug directory of the project
        string fileName = "Test.txt";
        Console.WriteLine("The used file is '{0}'.", fileName);
        try
        {
            StreamReader reader = new StreamReader(fileName, Encoding.GetEncoding("UTF-8"));
            StringBuilder newContent = new StringBuilder();
            using (reader)
            {
                uint lineNumber = 0;
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    lineNumber++;
                    if (lineNumber % 2 == 0)
                    {
                        newContent.Append(currentLine + Environment.NewLine);
                    }
                    currentLine = reader.ReadLine();
                }
            }
            StreamWriter writer = new StreamWriter(fileName, false, Encoding.GetEncoding("UTF-8"));
            using (writer)
            {
                writer.Write(newContent);
            }
            Console.WriteLine("Done! You can check the file.");
        }
        catch (FileNotFoundException fileException)
        {
            Console.WriteLine("File '{0}' cannot be found.", fileException.FileName);
        }
        catch (ArgumentException argException)
        {
            Console.WriteLine(argException.Message);
        }
        catch
        {
            Console.WriteLine("Fatal error occurred!");
        }
    }
}
