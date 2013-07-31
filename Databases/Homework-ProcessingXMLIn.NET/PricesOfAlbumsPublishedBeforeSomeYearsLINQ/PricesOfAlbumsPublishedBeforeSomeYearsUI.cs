using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

class PricesOfAlbumsPublishedBeforeSomeYearsUI
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Extracting all album prices from 'albums-catalogue.xml'");
        Console.WriteLine("published 5 years ago or earlier (LINQ to XML)***");
        Console.Write(decorationLine);

        XElement catalogueElement = XElement.Load("../../../albums-catalogue.xml");
        IEnumerable<XElement> albums =
            from album in catalogueElement.Elements("album")
            where int.Parse(album.Element("year").Value) <= (DateTime.Now.Year - 5)
            select album;

        foreach (XElement album in albums)
        {
            Console.WriteLine("{0} -> {1:C}",
                album.Element("name").Value, decimal.Parse(album.Element("price").Value));
        }
    }
}
