using System;
using System.Text;
using System.IO;
using System.Security;

class RemovingWordsFromATextFile
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Deleting from a text file all words that are listed in another text file***");
        Console.Write(decorationLine);
        // All files are in bin\Debug directory of the project
        string testFile = "Test.txt";
        string wordsFile = "Words.txt";
        Console.WriteLine("The words to be deleted from file '{0}' are in file '{1}'.", testFile, wordsFile);
        try
        {
            StreamReader reader1 = new StreamReader(testFile, Encoding.GetEncoding("UTF-8"));
            StreamReader reader2 = new StreamReader(wordsFile, Encoding.GetEncoding("UTF-8"));
            StringBuilder newContent = new StringBuilder();
            using (reader1)
            {
                using (reader2)
                {
                    char currentChar = new char();
                    string currentTestWord = null;
                    while (!reader1.EndOfStream)
                    {
                        currentChar = (char)reader1.Read();
                        if (char.IsLetterOrDigit(currentChar) || currentChar == '_')
                        {
                            currentTestWord += currentChar;
                        }
                        else
                        {
                            bool removeWord = false;
                            reader2.BaseStream.Position = 0;
                            reader2.DiscardBufferedData();
                            string wordInWordsFile = reader2.ReadLine();
                            while (wordInWordsFile != null)
                            {
                                if (currentTestWord == wordInWordsFile)
                                {
                                    removeWord = true;
                                    break;
                                }
                                wordInWordsFile = reader2.ReadLine();
                            }
                            if (!removeWord)
                            {
                                newContent.Append(currentTestWord);
                            }
                            newContent.Append(currentChar);
                            currentTestWord = null;
                        }
                    }
                }
            }
            StreamWriter writer = new StreamWriter(testFile, false, Encoding.GetEncoding("UTF-8"));
            using (writer)
            {
                writer.Write(newContent);
            }
            Console.WriteLine("Done! You can check the file.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The specified directory was not found!");
        }
        catch (SecurityException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You don't have the required permission to access the file!");
        }
        catch (FileNotFoundException fileException)
        {
            Console.WriteLine("File '{0}' cannot be found.", fileException.FileName);
        }
        catch (ArgumentException argException)
        {
            Console.WriteLine(argException.Message);
        }
        catch (IOException)
        {
            Console.WriteLine("Fatal error occured!");
        }
    }
}
