using System;
using System.Text;
using System.IO;

class ReplaceAWordWithAnotherInFile
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Replacing all occurences of the word \"start\" with the word \n\"finish\" in a text file***");
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
                char currentChar = new char();
                string word = null;
                while (!reader.EndOfStream)
                {
                    currentChar = (char)reader.Read();
                    if (char.IsLetter(currentChar))
                    {
                        word += currentChar;
                    }
                    else
                    {
                        if (word == "start")
                        {
                            newContent.Append("finish");
                        }
                        else
                        {
                            newContent.Append(word);
                        }
                        word = null;
                        newContent.Append(currentChar);
                    }
                }
                // Appending the last word
                if (word == "start")
                {
                    newContent.Append("finish");
                }
                else
                {
                    newContent.Append(word);
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
