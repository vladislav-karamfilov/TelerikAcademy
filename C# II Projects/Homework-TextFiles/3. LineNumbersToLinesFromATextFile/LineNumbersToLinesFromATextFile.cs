using System;
using System.IO;
using System.Text;

class LineNumbersToLinesFromATextFile
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Reading a file, inserting line numbers to its lines and \nwriting them to a new file***");
        Console.Write(decorationLine);
        // All files are in bin\Debug directory of the project
        string inputFile = "Input.txt";
        string outputFile = "Output.txt";
        Console.WriteLine("The read file is {0} and the file with the new content is {1}.", inputFile, outputFile);
        try
        {
            StreamReader reader = new StreamReader(inputFile, Encoding.GetEncoding("UTF-8"));
            StreamWriter writer = new StreamWriter(outputFile, false, Encoding.GetEncoding("UTF-8"));
            using (reader)
            {
                using (writer)
                {
                    uint lineNumber = 0;
                    string currentLine = reader.ReadLine();
                    while (currentLine != null)
                    {
                        lineNumber++;
                        writer.WriteLine("{0}. {1}", lineNumber, currentLine);
                        currentLine = reader.ReadLine();
                    }
                }
            }
            Console.WriteLine("Done! You can check the result in file '{0}'.", outputFile);
        }
        catch (FileNotFoundException fileException)
        {
            Console.WriteLine("File {0} cannot be found.", fileException.FileName);
        }
        catch (ArgumentException argException)
        {
            Console.WriteLine(argException.Message);
        }
        catch
        {
            Console.WriteLine("Fatal error occured.");
        }
    }
}
