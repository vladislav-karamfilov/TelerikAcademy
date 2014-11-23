namespace CreatePeopleXMLFile
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    class CreatePeopleXMLFileUI
    {
        const string PeopleInfoTextFilePath = "../../people-info.txt";
        const string PeopleInfoXmlFilePath = "../../people.xml";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Creating a people XML document with information from a text file***");
            Console.Write(decorationLine);

            CreatePeopleXMLFile();
            Console.WriteLine("Done!");
        }

        static void CreatePeopleXMLFile()
        {
            using (XmlTextWriter writer = new XmlTextWriter(PeopleInfoXmlFilePath, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("people");
                using (StreamReader reader = new StreamReader(PeopleInfoTextFilePath))
                {
                    string currentLine = reader.ReadLine();
                    while (currentLine != null)
                    {
                        string[] personInfo = currentLine.Split('|');
                        string name = personInfo[0].Trim();
                        string address = personInfo[1].Trim();
                        string phoneNumber = personInfo[2].Trim();
                        WritePerson(writer, name, address, phoneNumber);

                        currentLine = reader.ReadLine();
                    }
                }

                writer.WriteEndElement();
            }
        }

        static void WritePerson(XmlTextWriter writer, string name, string address, string phoneNumber)
        {
            writer.WriteStartElement("person");
            writer.WriteElementString("name", name);
            writer.WriteElementString("address", address);
            writer.WriteElementString("phoneNumber", phoneNumber);
            writer.WriteEndElement();
        }
    }
}
