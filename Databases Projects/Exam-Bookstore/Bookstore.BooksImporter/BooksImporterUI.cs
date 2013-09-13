namespace Bookstore.BooksImporter
{
    using System;
    using System.Xml;
    using System.Threading;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Transactions;
    using Bookstore.DataAccessLayer;

    class BooksImporterUI
    {
        const string DateFormat = "dd-MMM-yyyy";

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            BooksDAO booksDao = new BooksDAO();
            SimpleBooksImport(booksDao, "../../simple-books.xml");

            ComplexBooksImport(booksDao, "../../complex-books.xml");
            Console.WriteLine("Importing books completed!");
        }

        static void ComplexBooksImport(BooksDAO booksDao, string xmlFilePath)
        {
            XmlDocument catalogDocument = new XmlDocument();
            catalogDocument.Load(xmlFilePath);
            string xPathBooksQuery = "/catalog/book";
            XmlNodeList bookNodesList = catalogDocument.SelectNodes(xPathBooksQuery);
            foreach (XmlNode bookNode in bookNodesList)
            {
                string title = GetInnerXml(bookNode, "title").Trim();

                IList<string> authorNames = new List<string>();
                GetAuthors(bookNode, authorNames);

                IList<ReviewTransferObject> reviewTransferObjects =
                    new List<ReviewTransferObject>();
                GetReviews(bookNode, reviewTransferObjects);

                string isbn = GetInnerXml(bookNode, "isbn");

                string webSite = GetInnerXml(bookNode, "web-site");
                if (webSite != null)
                {
                    webSite = webSite.Trim();
                }

                decimal? price = null;
                string priceAsString = GetInnerXml(bookNode, "price");
                if (priceAsString != null)
                {
                    price = decimal.Parse(priceAsString);
                }

                using (TransactionScope transcationScope = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead }))
                {
                    booksDao.ComplexImportOfBook(authorNames, title, reviewTransferObjects, isbn, price, webSite);
                    transcationScope.Complete();
                }
            }
        }

        static void GetReviews(XmlNode bookNode, IList<ReviewTransferObject> reviewTransferObjects)
        {
            XmlNode reviewsNode = bookNode.SelectSingleNode("reviews");
            if (reviewsNode != null)
            {
                foreach (XmlNode reviewNode in reviewsNode.ChildNodes)
                {
                    string content = reviewNode.InnerXml.Trim();
                    XmlAttribute authorAttribute = reviewNode.Attributes["author"];
                    string author = null;
                    if (authorAttribute != null)
                    {
                        author = authorAttribute.InnerText.Trim();
                    }

                    DateTime date = DateTime.Now.Date;
                    XmlAttribute dateAttribute = reviewNode.Attributes["date"];
                    if (dateAttribute != null)
                    {
                        date = DateTime.Parse(dateAttribute.InnerText.Trim());
                    }

                    reviewTransferObjects.Add(new ReviewTransferObject()
                    {
                        Author = author,
                        Content = content,
                        Date = date
                    });
                }
            }
        }

        static void GetAuthors(XmlNode bookNode, IList<string> authorNames)
        {
            XmlNode authorsNode = bookNode.SelectSingleNode("authors");
            if (authorsNode != null)
            {
                foreach (XmlNode authorNode in authorsNode.ChildNodes)
                {
                    authorNames.Add(authorNode.InnerXml.Trim());
                }
            }
        }

        static void SimpleBooksImport(BooksDAO booksDao, string xmlFilePath)
        {
            XmlDocument catalogDocument = new XmlDocument();
            catalogDocument.Load(xmlFilePath);
            string xPathQuery = "/catalog/book";
            XmlNodeList bookNodesList = catalogDocument.SelectNodes(xPathQuery);
            foreach (XmlNode bookNode in bookNodesList)
            {
                string author = GetInnerXml(bookNode, "author").Trim();
                string title = GetInnerXml(bookNode, "title").Trim();
                string isbn = GetInnerXml(bookNode, "isbn");
                if (isbn != null)
                {
                    isbn = isbn.Trim();
                }

                string webSite = GetInnerXml(bookNode, "web-site");
                if (webSite != null)
                {
                    webSite = webSite.Trim();
                }

                decimal? price = null;
                string priceAsString = GetInnerXml(bookNode, "price");
                if (priceAsString != null)
                {
                    price = decimal.Parse(priceAsString);
                }

                booksDao.SimpleImportOfBook(author, title, isbn, price, webSite);
            }
        }

        static string GetInnerXml(XmlNode node, string xpath)
        {
            XmlNode innerNode = node.SelectSingleNode(xpath);
            if (innerNode != null)
            {
                return innerNode.InnerText;
            }

            return null;
        }
    }
}
