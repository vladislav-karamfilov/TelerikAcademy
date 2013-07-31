using System;
using System.IO;
using Wintellect.PowerCollections;

class StoringArticles
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Storing articles with barcode, vendor, title and price in");
        Console.WriteLine("data structure that allows fast retrieval by price in range [x..y]***");
        Console.Write(decorationLine);

        bool allowDuplicates = true;
        OrderedMultiDictionary<double, Article> articlesByPrice = 
            new OrderedMultiDictionary<double, Article>(allowDuplicates);
        string filePath = "../../articles.txt";
        char[] separators = new char[] { '-' };
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    string[] articleInfo = 
                        currentLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    Article article = new Article(
                        articleInfo[0].Trim(), 
                        articleInfo[1].Trim(), 
                        articleInfo[2].Trim(), 
                        double.Parse(articleInfo[3]));
                    articlesByPrice.Add(article.Price, article);

                    currentLine = reader.ReadLine();
                }
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The entered file path is not correct!");
            return;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file '{0}' was not found!", filePath);
            return;
        }
        catch (IOException)
        {
            Console.WriteLine("Error while opening the file occured!");
            return;
        }

        Console.WriteLine("All articles are:");
        PrintArticles(articlesByPrice);
        Console.WriteLine();

        double fromPrice = 10;
        double toPrice = 30;
        OrderedMultiDictionary<double, Article>.View articlesInRange =
            articlesByPrice.Range(fromPrice, true, toPrice, true);
        Console.WriteLine("-> All articles between {0:C} and {1:C} are:", fromPrice, toPrice);
        foreach (var article in articlesInRange)
        {
            Console.WriteLine(article.Value);
        }
    }

    private static void PrintArticles(OrderedMultiDictionary<double, Article> articles)
    {
        foreach (var article in articles)
        {
            Console.WriteLine(article.Value);
        }
    }
}
