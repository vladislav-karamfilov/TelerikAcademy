using System;
using System.IO;
using System.Text;

class ExtractTextFromHTMLFile
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Extracting all the text between the tags from given HTML file***");
        Console.Write(decorationLine);
        string file = "..\\..\\Test.html";
        Console.WriteLine("The used file is 'Test.html' in project's directory.");
        try
        {
            StreamReader reader = new StreamReader(file, Encoding.GetEncoding(1251));
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
            Console.WriteLine("The text between the tags from the HTML file is: ");
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
