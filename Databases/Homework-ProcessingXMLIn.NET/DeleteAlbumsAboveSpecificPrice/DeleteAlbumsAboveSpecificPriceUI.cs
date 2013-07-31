namespace DeleteAlbumsAboveSpecificPrice
{
    using System;
    using System.Xml;

    class DeleteAlbumsAboveSpecificPriceUI
    {
        const string XmlCatalogueFilePath = "../../albums-catalogue.xml";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Deleting all albums from 'catalog.xml' havin price > 20***");
            Console.Write(decorationLine);

            decimal maximalPrice = 20.0m;
            DeleteAlbums(maximalPrice);
            Console.WriteLine("All albums with price more than {0} deleted from 'catalogue.xml' file!",
                maximalPrice);
        }

        static void DeleteAlbums(decimal maximalPrice)
        {
            XmlDocument catalogueDocument = new XmlDocument();
            catalogueDocument.Load(XmlCatalogueFilePath);
            XmlNode catalogueNode = catalogueDocument.DocumentElement;
            XmlNodeList albumNodes = catalogueNode.ChildNodes;
            for (int i = 0; i < albumNodes.Count; i++)
            {
                decimal albumPrice = decimal.Parse(albumNodes[i]["price"].InnerText);
                if (albumPrice > maximalPrice)
                {
                    catalogueNode.RemoveChild(albumNodes[i]);
                    i--;
                }
            }

            catalogueDocument.Save(XmlCatalogueFilePath);
        }
    }
}
