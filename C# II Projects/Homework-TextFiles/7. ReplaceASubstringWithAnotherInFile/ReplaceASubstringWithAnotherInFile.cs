using System;
using System.Text;
using System.IO;

class ReplaceASubstringWithAnotherInFile
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Replacing all occurences of the substring \"start\" with the substring \n\"finish\" in a text file***");
        Console.Write(decorationLine);
        // The used file is in bin\Debug directory of the project
        string fileName = "Text.txt";
        Console.WriteLine("The text is in file '{0}'.", fileName);
        try
        {
            StreamReader reader = new StreamReader(fileName, Encoding.GetEncoding("UTF-8"));
            StringBuilder newContent = new StringBuilder();
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    newContent.Append(reader.ReadLine().ToLower().Replace("start", "finish") + Environment.NewLine);
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
            Console.WriteLine("Fatal error occured!");
        }
    }
}
