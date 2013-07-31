namespace GenerateFileSystemXml_XmlWriter
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    class GenerateFileSystemXmlUI
    {
        const string OutputFilePath = "../../directory.xml";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Creating a XML document from a directorie's content (XmlWriter)***");
            Console.Write(decorationLine);

            Console.WriteLine("Traversing the project's directory...");
            string directoryToTraverse = "../../";
            using (XmlTextWriter writer = new XmlTextWriter(OutputFilePath, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("directory");
                
                WriteDirectoryTag(writer, new DirectoryInfo(directoryToTraverse));

                writer.WriteEndDocument();
            }

            Console.WriteLine("Completed! You can see the result file in project's directory!");
        }

        static void WriteDirectoryTag(XmlWriter writer, DirectoryInfo directory)
        {
            writer.WriteStartElement("dir");
            writer.WriteAttributeString("name", directory.Name);
            foreach (FileInfo fileInfo in directory.GetFiles())
            {
                WriteFileTag(writer, fileInfo);
            }

            foreach (DirectoryInfo subdirectoryInfo in directory.GetDirectories())
            {
                WriteDirectoryTag(writer, subdirectoryInfo);
            }

            writer.WriteEndElement();
        }

        static void WriteFileTag(XmlWriter writer, FileInfo fileInfo)
        {
            writer.WriteStartElement("file");
            writer.WriteAttributeString("name", fileInfo.Name);
            writer.WriteAttributeString(
                "size-in-bytes", fileInfo.Length.ToString());
            writer.WriteEndElement();
        }
    }
}
