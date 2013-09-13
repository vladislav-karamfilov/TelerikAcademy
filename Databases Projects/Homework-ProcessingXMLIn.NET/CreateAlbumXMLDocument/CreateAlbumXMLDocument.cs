namespace CreateAlbumXMLDocument
{
    using System;
    using System.Text;
    using System.Xml;

    class CreateAlbumXMLDocumentUI
    {
        const string XmlCatalogueFilePath = "../../../albums-catalogue.xml";
        const string XmlAlbumFilePath = "../../album.xml";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Creating 'album.xml' document holding the name and artist");
            Console.WriteLine("of all albums in 'catalogue.xml'***");
            Console.Write(decorationLine);

            CreateAlbumXMLDocument();
            Console.WriteLine("Done!");
        }

        static void CreateAlbumXMLDocument()
        {
            using (XmlTextWriter writer = new XmlTextWriter(XmlAlbumFilePath, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");
                using (XmlReader reader = XmlReader.Create(XmlCatalogueFilePath))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) &&
                            reader.Name == "album")
                        {
                            reader.ReadToDescendant("name");
                            string name = reader.ReadInnerXml();

                            reader.ReadToNextSibling("artist");
                            string artist = reader.ReadInnerXml();
                            
                            WriteAlbum(writer, name, artist);
                        }
                    }
                }

                writer.WriteEndElement();
            }
        }

        static void WriteAlbum(XmlTextWriter writer, string name, string artist)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", name);
            writer.WriteElementString("artist", artist);
            writer.WriteEndElement();
        }
    }
}
