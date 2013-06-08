namespace FileSystemTree
{
    using System;

    public class File
    {
        private string name;
        private long size;

        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("File name cannot be null or white space");
                }

                foreach (char symbol in value)
                {
                    if (symbol == '\\' || symbol == '/' || symbol == '*' ||
                        symbol == '?' || symbol == '\"' || symbol == '<' ||
                        symbol == '>' || symbol == '|')
                    {
                        throw new ArgumentException(
                            "File name cannot contain any of the following symbols: \\/:*?\"<>|");
                    }
                }

                this.name = value;
            }
        }

        public long Size
        {
            get { return this.size; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("File size cannot be negative number!");
                }

                this.size = value;
            }
        }
    }
}
