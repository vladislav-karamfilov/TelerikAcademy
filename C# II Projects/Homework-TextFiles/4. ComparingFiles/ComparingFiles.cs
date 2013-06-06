using System;
using System.Text;
using System.IO;

class ComparingFiles
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Comparing two files line by line and printing how many lines are \nthe same and how many are different***");
        Console.Write(decorationLine);
        // All files are in bin\Debug directory of the project
        string fileName1 = "File1.txt";
        string fileName2 = "File2.txt";
        Console.WriteLine("The two files to be compared are '{0}' and '{1}'.", fileName1, fileName2);
        try
        {
            StreamReader reader1 = new StreamReader(fileName1, Encoding.GetEncoding("UTF-8"));
            StreamReader reader2 = new StreamReader(fileName2, Encoding.GetEncoding("UTF-8"));
            int differentLines = 0;
            int sameLines = 0;
            using (reader1)
            {
                using (reader2)
                {
                    string currentLine1 = reader1.ReadLine();
                    string currentLine2 = reader2.ReadLine();
                    while (currentLine1 != null) // The two files have the same number of lines
                    {
                        if (currentLine1 == currentLine2)
                        {
                            sameLines++;
                        }
                        else
                        {
                            differentLines++;
                        }
                        currentLine1 = reader1.ReadLine();
                        currentLine2 = reader2.ReadLine();
                    }
                }
            }
            Console.WriteLine("The number of different lines: {0}.", differentLines);
            Console.WriteLine("The number of same lines: {0}.", sameLines);
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
            Console.WriteLine("Fatal error occured!");
        }
    }
}
