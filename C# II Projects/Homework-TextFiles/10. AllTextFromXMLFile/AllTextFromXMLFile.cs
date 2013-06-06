using System;
using System.IO;
using System.Text;

class AllTextFromXMLFile
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Extracting all the text between the tags from given XML file***");
        Console.Write(decorationLine);
        // The used file is in bin\Debug directory of the project
        string fileName = "Books.xml";
        Console.WriteLine("The used file is '{0}'.", fileName);
        try
        {
            StreamReader reader = new StreamReader(fileName, Encoding.GetEncoding("UTF-8"));
            StringBuilder text = new StringBuilder();
            using (reader)
            {
                bool inTag = false;
                char currentChar = new char();
                string currentText = null;
                while (!reader.EndOfStream)
                {
                    currentChar = (char)reader.Read();
                    if (currentChar == '<')
                    {
                        inTag = true;
                        continue;
                    }
                    else if (currentChar == '>')
                    {
                        inTag = false;
                        continue;
                    }
                    if (!inTag)
                    {
                        currentText += currentChar;
                        if (currentChar == '\n' || reader.EndOfStream)
                        {
                            if (currentText.TrimStart(' ') != "\r\n") // If the line has just a tag, skip appending it
                            {
                                text.Append(currentText.TrimStart(' '));
                            }
                            currentText = null;
                        }
                    }
                }
            }
            Console.WriteLine("The text between the tags from the XML file is: ");
            Console.Write(text);
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
