namespace FileSystemTree
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;

    public class FileSystemDemo
    {
        private const string FileSystemDestination = "../../filesystem.txt";

        internal static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Implementing a file system starting from C:\\WINDOWS with");
            Console.WriteLine("operation of getting the total size of a folder by choice***");
            Console.Write(decorationLine);

            string rootFolderName = "WINDOWS";
            Folder rootFolder = new Folder(rootFolderName);
            string startPath = "C:";

            Console.Write("Building the file system. Takes some time...");
            BuildFileSystem(rootFolder, startPath);
            Console.WriteLine("\nBuild completed!");

            StringBuilder fileSystemString = new StringBuilder();
            BuildFileSystemString(rootFolder, fileSystemString);

            using (StreamWriter writer = new StreamWriter(FileSystemDestination))
            {
                writer.Write(fileSystemString);
            }

            Console.WriteLine(
                "{0}Look file '{1}' at project's directory to see the \nfile system string representation",
                Environment.NewLine,
                FileSystemDestination.Substring(FileSystemDestination.LastIndexOf('/') + 1));

            Console.WriteLine(
                "{0}The size of the '{1}\\{2}' folder is: {3} bytes",
                Environment.NewLine,
                startPath,
                rootFolderName,
                rootFolder.GetSize().ToString("0,0", CultureInfo.InvariantCulture));

            string folderName = "Fonts";
            Folder folder = GetFolderFromFileSystem(folderName, rootFolder);
            Console.WriteLine("\nThe size of the '{0}' folder in {1}\\{2} is: {3} bytes",
                folder.Name,
                startPath,
                rootFolderName,
                folder.GetSize().ToString("0,0", CultureInfo.InvariantCulture));
        }

        private static Folder GetFolderFromFileSystem(string name, Folder rootFolder)
        {
            if (rootFolder.Name == name)
            {
                return rootFolder;
            }

            Queue<Folder> folders = new Queue<Folder>();
            folders.Enqueue(rootFolder);
            while (folders.Count > 0)
            {
                Folder currentFolder = folders.Dequeue();
                foreach (Folder childFolder in currentFolder.ChildFolders)
                {
                    if (childFolder.Name == name)
                    {
                        return childFolder;
                    }
                    else
                    {
                        folders.Enqueue(childFolder);
                    }
                }
            }

            throw new DirectoryNotFoundException(string.Format(
                "Folder with name {0} does not exist in {1} directory!",
                name,
                rootFolder.Name));
        }

        private static void BuildFileSystemString(Folder rootFolder, StringBuilder fileSystemString)
        {
            foreach (Folder folder in rootFolder.ChildFolders)
            {
                BuildFileSystemString(folder, fileSystemString);
            }

            fileSystemString.AppendFormat(">>> Folder: {1}{0}", Environment.NewLine, rootFolder.Name);

            if (rootFolder.Files.Count > 0)
            {
                fileSystemString.AppendLine("--- Files: ");
                foreach (File file in rootFolder.Files)
                {
                    fileSystemString.AppendFormat("{0} -> {1} bytes{2}", file.Name, file.Size, Environment.NewLine);
                }
            }

            fileSystemString.AppendLine();
        }

        private static void BuildFileSystem(Folder rootFolder, string currentPath)
        {
            string currentFullPath = string.Format("{0}\\{1}", currentPath, rootFolder.Name);
            DirectoryInfo currentDirectory = new DirectoryInfo(currentFullPath);

            DirectoryInfo[] subdirectories = null;
            try
            {
                subdirectories = currentDirectory.GetDirectories();
                foreach (DirectoryInfo subdirectory in subdirectories)
                {
                    Folder newChildFolder = new Folder(subdirectory.Name);
                    rootFolder.AddChildFolder(newChildFolder);
                    BuildFileSystem(newChildFolder, currentFullPath);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Skip directories to which permission to access is not granted
                return;
            }

            FileInfo[] files = null;
            try
            {
                files = currentDirectory.GetFiles();
                foreach (FileInfo file in files)
                {
                    rootFolder.AddFile(new File(file.Name, file.Length));
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Skip files to which permission to access is not granted                
                return;
            }
        }
    }
}
