using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

class SortingListOfNamesFromFile
{
    static List<String> names = new List<string>();

    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Reading a file containing a list of names, sorting it and writing \nthe result list in a new file***");
        Console.Write(decorationLine);
        // All files are in bin\Debug directory of the project
        try
        {
            string inputFile = "Input.txt";
            string resultFile = "Output.txt";
            Console.WriteLine("The file that contains the list of names is '{0}'.", inputFile);
            ReadListFromFile(inputFile);
            names.Sort(); // Sorting the list of names
            PrintListToFile(resultFile);
            Console.WriteLine("You can view the sorted list of names in '{0}'.", resultFile);
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
            Console.WriteLine("Fatal error occured!");
        }
    }

    static void PrintListToFile(string resultFile)
    {
        StreamWriter writer = new StreamWriter(resultFile, false, Encoding.GetEncoding("UTF-8"));
        using (writer)
        {
            foreach (string name in names)
            {
                writer.WriteLine(name);
            }
        }
    }

    static void ReadListFromFile(string inputFile)
    {
        StreamReader reader = new StreamReader(inputFile, Encoding.GetEncoding("UTF-8"));
        using (reader)
        {
            string name = reader.ReadLine();
            while (name != null)
            {
                names.Add(name);
                name = reader.ReadLine();
            }
        }
    }
}