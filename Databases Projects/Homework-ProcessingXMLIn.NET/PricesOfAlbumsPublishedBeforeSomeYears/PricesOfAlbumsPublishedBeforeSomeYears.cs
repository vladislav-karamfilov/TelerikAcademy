using System;
using System.Xml;

class PricesOfAlbumsPublishedBeforeSomeYearsUI
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Extracting all album prices from 'albums-catalogue.xml'");
        Console.WriteLine("published 5 years ago or earlier (XPath)***");
        Console.Write(decorationLine);

        XmlDocument catalogueDocument = new XmlDocument();
        catalogueDocument.Load("../../../albums-catalogue.xml");

        string xPathQuery = string.Format("/catalogue/album[year <= {0}]", DateTime.Now.Year - 5);
        XmlNodeList albums = catalogueDocument.SelectNodes(xPathQuery);
        foreach (XmlNode album in albums)
        {
            Console.WriteLine("{0} -> {1:C}", 
                album["name"].InnerXml, decimal.Parse(album["price"].InnerXml));
        }
    }
}
