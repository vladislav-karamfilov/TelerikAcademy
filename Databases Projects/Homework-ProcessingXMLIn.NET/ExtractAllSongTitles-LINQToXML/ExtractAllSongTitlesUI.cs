namespace ExtractAllSongTitles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

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
            XDocument catalogueDocument = XDocument.Load(XmlCatalogueFilePath);
            var songTitles =
                from album in catalogueDocument.Descendants("album")
                    from song in album.Descendants("song")
                    select song.Element("title").Value;

            return songTitles;
        }
    }
}
