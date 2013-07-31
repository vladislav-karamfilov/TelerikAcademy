namespace ValidateXMLFIleAgainstXSDSchema
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;

    class ValidateXMLFIleAgainstXSDSchemaUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Validating the 'albums-catalogue.xml' document against");
            Console.WriteLine("'albums-catalogue.xsd' schema***");
            Console.Write(decorationLine);

            string xsdSchemaFilePath = "../../../albums-catalogue.xsd";

            bool isValid = true;
            string validCatalogueXmlFilePath = "../../valid-albums-catalogue.xml";
            isValid = TestForValidity(validCatalogueXmlFilePath, xsdSchemaFilePath);
            PrintResult(isValid, validCatalogueXmlFilePath);

            string invalidCatalogueXmlFilePath = "../../invalid-albums-catalogue.xml";
            isValid = TestForValidity(invalidCatalogueXmlFilePath, xsdSchemaFilePath);
            PrintResult(isValid, invalidCatalogueXmlFilePath);
        }

        static void PrintResult(bool isValid, string filePath)
        {
            if (isValid)
            {
                Console.WriteLine("'{0}' XML document is valid!",
                    filePath.Substring(filePath.LastIndexOf('/') + 1));
            }
            else
            {
                Console.WriteLine("'{0}' XML document is not valid!",
                        filePath.Substring(filePath.LastIndexOf('/') + 1));
            }
        }

        static bool TestForValidity(string catalogueXmlFilePath, string catalogueXsdSchemaFilePath)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, catalogueXsdSchemaFilePath);
                settings.ValidationType = ValidationType.Schema;
                XmlDocument document = new XmlDocument();
                document.Load(catalogueXmlFilePath);
                XmlReader rdr = XmlReader.Create(new StringReader(document.InnerXml), settings);
                while (rdr.Read()) { }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
