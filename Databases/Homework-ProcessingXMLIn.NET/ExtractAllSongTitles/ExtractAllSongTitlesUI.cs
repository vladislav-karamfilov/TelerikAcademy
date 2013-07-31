namespace ExtractAllSongTitles
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class ExtractAllSongTitlesUI
    {
        const string XmlCatalogueFilePath = "../../../albums-catalogue.xml";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Extracting all song titles found in 'catalogue.xml' file***");
            Console.Write(decorationLine);

            IEnumerable<string> songTitles = GetSongTitles();
            Console.WriteLine("All song titles are: '{0}'", string.Join("', '", songTitles));
        }

        static IEnumerable<string> GetSongTitles()
        {
            IList<string> songTitles = new List<string>();
            using (XmlReader reader = XmlReader.Create(XmlCatalogueFilePath))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element)
                        && reader.Name == "title")
                    {
                        songTitles.Add(reader.ReadInnerXml());
                    }
                }
            }

            return songTitles;
        }
    }
}
