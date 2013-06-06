using System;
using System.Text;
using System.IO;

class DeleteWordsStartingWithTest
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Deleting all words starting with the prefix 'test' from a text file***");
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
                char currentChar = new char();
                string currentWord = null;
                while (!reader.EndOfStream)
                {
                    currentChar = (char)reader.Read();
                    if (char.IsLetterOrDigit(currentChar) || currentChar == '_')
                    {
                        currentWord += currentChar;
                    }
                    else
                    {
                        if (currentWord != null && currentWord.StartsWith("test") == false)
                        {
                            newContent.Append(currentWord);
                        }
                        currentWord = null;
                        newContent.Append(currentChar);
                    }
                }
                // Appending the last word
                if (currentWord != null && !currentWord.StartsWith("test"))
                {
                    newContent.Append(currentWord); 
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
