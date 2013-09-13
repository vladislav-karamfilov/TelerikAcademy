using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace SQLiteBooksDBManipulation
{
    class SQLiteBooksDBManipulationUI
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Methods for adding books, finding books by name and listing books");
            Console.WriteLine("from 'BookSystem' SQLite database***");
            Console.Write(decorationLine);

            SQLiteConnection dbConnection = new SQLiteConnection(Settings.Default.SQLiteConnectonString);
            dbConnection.Open();
            using (dbConnection)
            {
                int booksDetailsCount = 5;
                IList<object[]> booksDetails = GetbooksDetails(booksDetailsCount);

                AddNewBooks(booksDetails, dbConnection);
                Console.WriteLine("--- {0} books added to the database", booksDetailsCount);
                Console.WriteLine();

                IList<string> books = ListAllBooks(dbConnection);
                Console.WriteLine("--- All books in the database are: ");
                foreach (string book in books)
                {
                    Console.WriteLine(book);
                }

                string bookTitle = "Title 4";
                string bookByTitle = GetBookInfoWithTitle(bookTitle, dbConnection);
                if (bookByTitle != null)
                {
                    Console.WriteLine("--- Book information about a book with title '{0}': \n{1}",
                        bookTitle, bookByTitle);
                }
                else
                {
                    Console.WriteLine("--- There is no book with title {0}", bookTitle);
                }
            }
        }

        static string GetBookInfoWithTitle(string bookTitle, SQLiteConnection dbConnection)
        {
            SQLiteCommand getBookWithTitleCommand = new SQLiteCommand(
               @"SELECT Title, Author, PublishDate, ISBN FROM Books
                      WHERE Title = @title", dbConnection);

            getBookWithTitleCommand.Parameters.AddWithValue("@title", bookTitle);
            SQLiteDataReader bookInfo = getBookWithTitleCommand.ExecuteReader();
            if (bookInfo.HasRows)
            {
                bookInfo.Read();
                StringBuilder book = new StringBuilder();
                book.AppendFormat("Title: {0}{1}", (string)bookInfo["Title"], Environment.NewLine);
                book.AppendFormat("Author: {0}{1}", (string)bookInfo["Author"], Environment.NewLine);
                book.AppendFormat("Publish date: {0}{1}", bookInfo["PublishDate"] == DBNull.Value ?
                    "Unknown" : ((DateTime)bookInfo["PublishDate"]).ToShortDateString(), Environment.NewLine);
                book.AppendFormat("ISBN: {0}{1}", (string)bookInfo["ISBN"], Environment.NewLine);

                bookInfo.Close();
                return book.ToString();
            }
            else
            {
                bookInfo.Close();
                return null;
            }
        }

        static IList<string> ListAllBooks(SQLiteConnection dbConnection)
        {
            IList<string> books = new List<string>();

            SQLiteCommand selectAllBooksCommand = new SQLiteCommand(
                @"SELECT Title, Author, PublishDate, ISBN
                      FROM Books", dbConnection);

            SQLiteDataReader booksDetails = selectAllBooksCommand.ExecuteReader();
            while (booksDetails.Read())
            {
                StringBuilder book = new StringBuilder();
                book.AppendFormat("Title: {0}{1}", (string)booksDetails["Title"], Environment.NewLine);
                book.AppendFormat("Author: {0}{1}", (string)booksDetails["Author"], Environment.NewLine);
                book.AppendFormat("Publish date: {0}{1}", booksDetails["PublishDate"] == DBNull.Value ?
                    "Unknown" : ((DateTime)booksDetails["PublishDate"]).ToShortDateString(), Environment.NewLine);
                book.AppendFormat("ISBN: {0}{1}", (string)booksDetails["ISBN"], Environment.NewLine);

                books.Add(book.ToString());
            }

            return books;
        }


        static void AddNewBooks(IList<object[]> booksDetails, SQLiteConnection dbConnection)
        {
            SQLiteCommand insertNewBookCommand = new SQLiteCommand(
                    @"INSERT INTO Books (Title, Author, PublishDate, ISBN)
                        VALUES (@title, @author, @publishDate, @isbn)", dbConnection);

            for (int i = 0; i < booksDetails.Count; i++)
            {
                insertNewBookCommand.Parameters.AddWithValue("@title", booksDetails[i][0] as string);
                insertNewBookCommand.Parameters.AddWithValue("@author", booksDetails[i][1] as string);
                SQLiteParameter publishDate = new SQLiteParameter("@publishDate", booksDetails[i][2] as DateTime?);
                if (booksDetails[i][2] == null)
                {
                    publishDate.Value = DBNull.Value;
                }

                insertNewBookCommand.Parameters.Add(publishDate);
                insertNewBookCommand.Parameters.AddWithValue("@isbn", booksDetails[i][3] as string);

                insertNewBookCommand.ExecuteNonQuery();
                insertNewBookCommand.Parameters.Clear();
            }
        }

        static IList<object[]> GetbooksDetails(int booksDetailsCount)
        {
            IList<object[]> booksDetails = new List<object[]>(booksDetailsCount);
            for (int i = 0; i < booksDetailsCount; i++)
            {
                object[] bookDetails = new object[4];
                bookDetails[0] = string.Format("Title {0}", i);
                bookDetails[1] = string.Format("Author {0}", i);
                bookDetails[2] = DateTime.Now.Subtract(new TimeSpan(i, 0, 0, 0));
                bookDetails[3] = string.Format("{0}{0}{0}-{0}-{0}{0}-{0}{0}{0}{0}{0}{0}-{0}", i);

                booksDetails.Add(bookDetails);
            }

            return booksDetails;
        }
    }
}
