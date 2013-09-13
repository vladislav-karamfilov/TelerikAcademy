namespace GenerateFileSystemXml_XmlWriter
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    class GenerateFileSystemXmlUI
    {
        const string OutputFilePath = "../../directory.xml";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Creating a XML document from a directorie's content (LINQ to XML)***");
            Console.Write(decorationLine);

            Console.WriteLine("Traversing the project's directory...");
            string directoryToTraverse = "../../";
            DirectoryInfo directory = new DirectoryInfo(directoryToTraverse);
            XDocument directoryDocument = new XDocument();
            XElement directoryElement = new XElement("directory");
            WriteDirectoryTag(directoryElement, directory);
            directoryDocument.Add(directoryElement);
            directoryDocument.Save(OutputFilePath);
            Console.WriteLine("Completed! You can see the result file in project's directory!");
        }

        static void WriteDirectoryTag(XElement element, DirectoryInfo directory)
        {
            XElement directoryElement = new XElement("dir", new XAttribute("name", directory.Name));
            element.Add(directoryElement);
            foreach (FileInfo fileInfo in directory.GetFiles())
            {
                directoryElement.Add(new XElement(
                        "file", 
                        new XAttribute("name", fileInfo.Name), 
                        new XAttribute("size-in-bytes", fileInfo.Length)));
            }

            foreach (DirectoryInfo subdirectoryInfo in directory.GetDirectories())
            {
                WriteDirectoryTag(directoryElement, subdirectoryInfo);
            }
        }
    }
}
