using System;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;

class ProductsInRangeFinder
{
    static readonly OrderedBag<Product> products = new OrderedBag<Product>();

    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the first 20 products in some price range from a");
        Console.WriteLine("collection of 500 000 products 10 000 times***");
        Console.Write(decorationLine);

        string productsFilePath = @"../../products.txt";
        string productsInRangeFilePath = @"../../products-in-range.txt";

        WriteProductsToFile(productsFilePath);

        ReadProductsFromFile(productsFilePath);

        WriteProductsInRangeToFile(productsInRangeFilePath);

        Console.WriteLine("You can see the result in file: '{0}'",
            productsInRangeFilePath.Substring(productsInRangeFilePath.LastIndexOf('/') + 1));
    }

    private static void WriteProductsInRangeToFile(string productsInRangeFilePath)
    {
        using (StreamWriter writer = new StreamWriter(productsInRangeFilePath))
        {
            for (int i = 0; i < 10000; i++)
            {
                Product fromProduct = new Product("From product", (500 + i) % 100000);
                Product toProduct = new Product("To product", (1000 + i) % 100000);
                var productsFrom500To1000 = 
                    products.Range(fromProduct, true, toProduct, true).Take(20);
                
                foreach (var product in productsFrom500To1000)
                {
                    writer.WriteLine(product);
                }

                writer.WriteLine();
            }
        }
    }

    private static void ReadProductsFromFile(string productsFilePath)
    {
        char[] separators = new char[] { '|' };

        using (StreamReader reader = new StreamReader(productsFilePath))
        {
            string currentLine = reader.ReadLine();
            while (currentLine != null)
            {
                string[] productNameAndPrice =
                    currentLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                Product product =
                    new Product(productNameAndPrice[0], double.Parse(productNameAndPrice[1]));
                products.Add(product);

                currentLine = reader.ReadLine();
            }
        }
    }

    private static void WriteProductsToFile(string productsFilePath)
    {
        using (StreamWriter writer = new StreamWriter(productsFilePath))
        {
            for (int i = 0; i < 500000; i++)
            {
                string productName = string.Format("Product {0}", i);
                double productPrice = (i % 100000) + 0.99;

                writer.WriteLine(string.Format("{0} | {1}", productName, productPrice));
            }
        }
    }
}
