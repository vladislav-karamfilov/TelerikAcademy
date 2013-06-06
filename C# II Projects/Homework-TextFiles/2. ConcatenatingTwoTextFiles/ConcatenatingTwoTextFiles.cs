using System;
using System.Text;
using System.IO;

class ConcatenatingTwoTextFiles
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Concatenating two text files into another text file***");
        Console.Write(decorationLine);
        // All files are in bin\Debug directory of the project
        string fileName1 = "First.txt";
        string fileName2 = "Second.txt";
        string fileName3 = "Result.txt";
        Console.WriteLine("The two files to be concatenated are {0} and {1}.", fileName1, fileName2);
        try
        {
            StreamReader reader1 = new StreamReader(fileName1, Encoding.GetEncoding(1251));
            StreamReader reader2 = new StreamReader(fileName2, Encoding.GetEncoding(1251));
            StreamWriter writer = new StreamWriter(fileName3, false, Encoding.GetEncoding(1251));
            using (writer)
            {
                using (reader1)
                {
                    string fileContent = reader1.ReadToEnd();
                    writer.Write(fileContent);
                    writer.WriteLine(); // So the second file's content starts on a new line
                }
                using (reader2)
                {
                    string fileContent = reader2.ReadToEnd();
                    writer.Write(fileContent);
                }
            }
            Console.WriteLine("Done! You can check the result in file '{0}'.", fileName3);
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
}
