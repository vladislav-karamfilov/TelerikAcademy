namespace Bookstore.ReviewsSearcher
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Threading;
    using System.Xml;
    using Bookstore.DataAccessLayer;
    using Bookstore.Logs.Data;
    using Bookstore.Logs.Models;

    class ReviewsSearcherUI
    {
       const string DateFormat = "dd-MMM-yyyy";

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            XmlDocument queryDocument = new XmlDocument();
            queryDocument.Load("../../reviews-queries.xml");
            using (XmlTextWriter writer = new XmlTextWriter("../../reviews-search-results.xml", Encoding.UTF8))
            {
                InitializeWriter(writer);

                writer.WriteStartDocument();
                writer.WriteStartElement("search-results");

                ReviewsDAO reviewsDao = new ReviewsDAO();

                using (LogsContext logsContext = new LogsContext())
                {
                    XmlNodeList queryNodes = queryDocument.SelectNodes("/review-queries/query");
                    foreach (XmlNode queryNode in queryNodes)
                    {
                        LogQuery(logsContext, queryNode.OuterXml);

                        WriteResultSet(writer, reviewsDao, queryNode);
                    }

                    writer.WriteEndDocument();
                }
            }

            Console.WriteLine("Done! See the file in project's directory.");
        }

        static void WriteResultSet(XmlTextWriter writer, ReviewsDAO reviewsDao, XmlNode queryNode)
        {
            IEnumerable<FoundReviewTransferObject> foundReviews = null;
            string searchType = queryNode.Attributes["type"].InnerText;
            if (searchType == "by-period")
            {
                DateTime startDate = DateTime.Parse(
                    queryNode.SelectSingleNode("start-date").InnerXml);

                DateTime endDate = DateTime.Parse(
                    queryNode.SelectSingleNode("end-date").InnerXml);
                foundReviews = reviewsDao.GetReviewsByPeriod(startDate, endDate);
            }
            else if (searchType == "by-author")
            {
                string authorName = queryNode.SelectSingleNode("author-name")
                    .InnerXml.Trim().ToLower();
                foundReviews = reviewsDao.GetReviewsByAuthorName(authorName);
            }
            else
            {
                return;
            }

            writer.WriteStartElement("result-set");
            if (foundReviews != null)
            {
                foreach (var review in foundReviews)
                {
                    WriteFoundReview(writer, review);
                }
            }

            writer.WriteEndElement();
        }

        static void LogQuery(LogsContext context, string queryXml)
        {
            SearchLog newLog = new SearchLog();
            newLog.Date = DateTime.Now;
            newLog.QueryXml = queryXml;

            context.SearchLogs.Add(newLog);
            context.SaveChanges();
        }

        static void InitializeWriter(XmlTextWriter writer)
        {
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;
        }

        static void WriteFoundReview(XmlTextWriter writer, FoundReviewTransferObject review)
        {
            writer.WriteStartElement("review");

            if (review.Date != null)
            {
                writer.WriteElementString("date", review.Date.Value.ToString(DateFormat));
            }

            writer.WriteElementString("content", review.Content);

            writer.WriteStartElement("book");
            writer.WriteElementString("title", review.BookTitle);
            if (review.BookAuthors != null)
            {
                writer.WriteElementString("authors", review.BookAuthors);
            }

            if (review.BookIsbn != null)
            {
                writer.WriteElementString("isbn", review.BookIsbn);
            }

            if (review.BookUrl != null)
            {
                writer.WriteElementString("url", review.BookUrl);
            }

            writer.WriteEndElement();

            writer.WriteEndElement();
        }
    }
}
