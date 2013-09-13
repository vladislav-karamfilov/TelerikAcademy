namespace Bookstore.BookSearcher
{
    using System;
    using System.Xml;
    using Bookstore.DataAccessLayer;
    using System.Collections.Generic;
    using System.Linq;

    class BookSearcherUI
    {
        static void Main()
        {
            BooksDAO booksDao = new BooksDAO();

            XmlDocument queryDocument = new XmlDocument();
            queryDocument.Load("../../simple-query.xml");

            string title = GetTitle(queryDocument);
            string author = GetAuthorName(queryDocument);
            string isbn = GetIsbn(queryDocument);

            IEnumerable<FoundBookTransferObject> foundBooksInfos = 
                booksDao.SearchBooks(title, author, isbn);
            int booksInfosCount = foundBooksInfos.Count();
            if (booksInfosCount != 0)
            {
                Console.WriteLine("{0} books found:", booksInfosCount);
                foreach (FoundBookTransferObject bookInfo in foundBooksInfos)
                {
                    int reviewsCount = bookInfo.ReviewsCount;
                    Console.WriteLine("{0} --> {1} reviews",
                        bookInfo.BookTitle, 
                        reviewsCount != 0 ? bookInfo.ReviewsCount.ToString() : "no");
                }
            }
            else
            {
                Console.WriteLine("Nothing found");
            }
        }

        static string GetIsbn(XmlDocument queryDocument)
        {
            string xpathQueryForIsbn = "/query/isbn";
            XmlNode isbnNode = queryDocument.SelectSingleNode(xpathQueryForIsbn);
            string isbn = null;
            if (isbnNode != null)
            {
                isbn = isbnNode.InnerXml.Trim();
            }

            return isbn;
        }

        static string GetAuthorName(XmlDocument queryDocument)
        {
            string xpathQueryForAuthor = "/query/author";
            XmlNode authorNode = queryDocument.SelectSingleNode(xpathQueryForAuthor);
            string author = null;
            if (authorNode != null)
            {
                author = authorNode.InnerXml.Trim().ToLower();
            }

            return author;
        }

        static string GetTitle(XmlDocument queryDocument)
        {
            string xpathQueryForTitle = "/query/title";
            XmlNode titleNode = queryDocument.SelectSingleNode(xpathQueryForTitle);
            string title = null;
            if (titleNode != null)
            {
                title = titleNode.InnerXml.Trim().ToLower();
            }

            return title;
        }
    }
}
