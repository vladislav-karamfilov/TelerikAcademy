using System;
using System.IO;
using System.Text;

class ReplaceTagsInHTMLFile
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Replacing all the tags <a href=\"...\">...</a> with [URL=...]...[/URL]***");
        Console.Write(decorationLine);
        string file = "..\\..\\Test.html";
        Console.WriteLine("The used file is 'Test.html' in project's directory.");
        try
        {
            StreamReader reader = new StreamReader(file, Encoding.GetEncoding(1251));
            string content = null;
            using (reader)
            {
                content = reader.ReadToEnd();
                content = content.Replace("<a href=\"", "[URL=");
                content = content.Replace("\">", "]");
                content = content.Replace("</a>", "[/URL]");
            }
            Console.WriteLine("After the replacement the content of the file is:\n" + content);
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
