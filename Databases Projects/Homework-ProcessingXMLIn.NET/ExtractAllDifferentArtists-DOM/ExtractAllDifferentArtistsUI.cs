namespace ExtractAllDifferentArtists
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class ExtractAllDifferentArtistsUI
    {
        const string XmlCatalogueFilePath = "../../../albums-catalogue.xml";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Extracting all different artists found in 'catalogue.xml' file (DOM)***");
            Console.Write(decorationLine);

            IDictionary<string, int> artistsAlbumsCount = GetArtistsAlbumsCount();
            Console.WriteLine("The artists with their albums count are:");
            foreach (var artistAlbumsCount in artistsAlbumsCount)
            {
                Console.WriteLine("{0} -> {1}", artistAlbumsCount.Key, artistAlbumsCount.Value);
            }
        }

        static IDictionary<string, int> GetArtistsAlbumsCount()
        {
            XmlDocument catalogueDocument = new XmlDocument();
            catalogueDocument.Load(XmlCatalogueFilePath);
            XmlNode catalogueNode = catalogueDocument.DocumentElement;
            IDictionary<string, int> artistsAlbumsCount = new Dictionary<string, int>();
            foreach (XmlNode album in catalogueNode.ChildNodes)
            {
                string artist = album["artist"].InnerText;
                if (artistsAlbumsCount.ContainsKey(artist))
                {
                    artistsAlbumsCount[artist]++;
                }
                else
                {
                    artistsAlbumsCount[artist] = 1;
                }
            }

            return artistsAlbumsCount;
        }
    }
}
