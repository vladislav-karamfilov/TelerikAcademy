using System;
using System.Collections.Generic;
using System.IO;

public class WindowsExeFilesGetter
{
    internal static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Traversing the C:\\WINDOWS directory and all its subdirectories recursively");
        Console.WriteLine("and displaying all '.exe' files in them. Takes some time...***");
        Console.Write(decorationLine);
        
        string windowsDirectory = @"C:\WINDOWS";
        string mask = "*.exe";
        List<FileInfo> allExeFiles = GetFiles(windowsDirectory, mask);

        Console.WriteLine("All exe files in the {0} directory are:", windowsDirectory);
        PrintFilesToConsole(allExeFiles);
    }

    private static void PrintFilesToConsole(List<FileInfo> files)
    {
        foreach (FileInfo file in files)
        {
            Console.WriteLine(file.Name);
        }
    }

    // Performs Depth-First Search using a stack
    // Change the 'Stack' data structure to 'Queue' and Breath-First Search will be performed
    private static List<FileInfo> GetFiles(string rootDirectory, string mask)
    {
        if (!Directory.Exists(rootDirectory))
        {
            throw new ArgumentException(
                string.Format("Directory '{0}' does not exist!", rootDirectory),
                "directory");
        }

        List<FileInfo> filesMatchedToMask = new List<FileInfo>();

        Stack<string> directories = new Stack<string>();
        directories.Push(rootDirectory);
        while (directories.Count > 0)
        {
            string currentDirectory = directories.Pop();
            string[] subdirectories = null;
            try
            {
                subdirectories = Directory.GetDirectories(currentDirectory);
                foreach (string subdirectory in subdirectories)
                {
                    directories.Push(subdirectory);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Skip directories to which permission to access is not granted         
                continue;
            }

            string[] filesInCurrentDirectory = null;
            try
            {
                filesInCurrentDirectory = Directory.GetFiles(currentDirectory, mask);
                foreach (string file in filesInCurrentDirectory)
                {
                    filesMatchedToMask.Add(new FileInfo(file));
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Skip files to which permission to access is not granted
                continue;
            }
        }

        return filesMatchedToMask;
    }
}
