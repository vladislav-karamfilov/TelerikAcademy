using System;
using System.IO;
using System.Text;

class OddLinesOfATextFile
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Reading a text file and printing its odd lines***");
        Console.Write(decorationLine);
        string fileName = "SomeText.txt";
        Console.WriteLine("The read file is '{0}' which is in project's directory.", fileName);
        try
        {
            StreamReader reader = new StreamReader("..\\..\\SomeText.txt", Encoding.GetEncoding(1251));
            using (reader)
            {
                int lineNumber = 0;
                string currentLine = reader.ReadLine();
                if (currentLine != null)
                {
                    Console.WriteLine("The content on the odd lines of the file: ");
                }
                while (currentLine != null)
                {
                    lineNumber++;
                    if (lineNumber % 2 == 1)
                    {
                        Console.WriteLine(currentLine);
                    }
                    currentLine = reader.ReadLine();
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Cannot find file '{0}'.", fileName);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch
        {
            Console.WriteLine("Fatal error occured!");
        }
    }
}
