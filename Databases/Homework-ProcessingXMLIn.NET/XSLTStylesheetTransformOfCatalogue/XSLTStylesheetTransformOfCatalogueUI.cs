using System;
using System.Xml.Xsl;

class XSLTStylesheetTransformOfCatalogueUI
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Transforming the XML document 'albums-catalogue.xml' to a HTML");
        Console.WriteLine("file using 'albums-catalogue.xsl' stylesheet file with XSLT***");
        Console.Write(decorationLine);

        XslCompiledTransform xslTransformer = new XslCompiledTransform();
        xslTransformer.Load("../../albums-catalogue.xsl");
        xslTransformer.Transform("../../albums-catalogue.xml", "../../albums-catalogue.html");
        
        Console.WriteLine("Completed! You can see the HTML file in project's directory!");
    }
}
