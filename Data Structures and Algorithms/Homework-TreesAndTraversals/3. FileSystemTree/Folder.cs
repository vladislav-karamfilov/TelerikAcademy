namespace FileSystemTree
{
    using System;
    using System.Collections.Generic;

    public class Folder
    {
        private string name;
        private readonly List<File> files;
        private readonly List<Folder> childFolders;

        public Folder(string name)
        {
            this.Name = name;
            this.files = new List<File>();
            this.childFolders = new List<Folder>();
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Folder name cannot be null or white space");
                }

                foreach (char symbol in value)
                {
                    if (symbol == '\\' || symbol == '/' || symbol == '*' ||
                        symbol == '?' || symbol == '\"' || symbol == '<' ||
                        symbol == '>' || symbol == '|')
                    {
                        throw new ArgumentException(
                            "Folder name cannot contain any of the following symbols: \\/:*?\"<>|");
                    }
                }

                this.name = value;
            }
        }

        public List<File> Files
        {
            get { return this.files; }
        }

        public List<Folder> ChildFolders
        {
            get { return this.childFolders; }
        }

        public void AddFile(File newFile)
        {
            this.files.Add(newFile);
        }

        public void AddChildFolder(Folder newFolder)
        {
            this.childFolders.Add(newFolder);
        }

        public long GetSize()
        {
            long sum = 0;
            foreach (Folder folder in this.ChildFolders)
            {
                sum += folder.GetSize();
            }

            foreach (File file in this.Files)
            {
                sum += file.Size;
            }

            return sum;
        }
    }
}
