namespace Bookstore.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bookstore.Data;

    public class BooksDAO
    {
        // Tasks 3
        public void SimpleImportOfBook(string authorName, string title, string isbn, decimal? price, string webSite)
        {
            BookstoreEntities context = new BookstoreEntities();

            Book newBook = new Book();
            Author author = CreateOrLoadAuthor(context, authorName);
            newBook.Authors.Add(author);
            newBook.ISBN = isbn;
            newBook.Price = price;
            newBook.Title = title;
            newBook.WebSite = webSite;

            context.Books.Add(newBook);
            context.SaveChanges();
        }

        // Task 4
        public void ComplexImportOfBook(
            IList<string> authorsNames,
            string title,
            IList<ReviewTransferObject> reviewTransferObjects,
            string isbn,
            decimal? price,
            string webSite)
        {
            BookstoreEntities context = new BookstoreEntities();

            Book newBook = new Book();
            newBook.ISBN = isbn;
            newBook.Title = title;
            newBook.Price = price;
            newBook.WebSite = webSite;

            foreach (string authorName in authorsNames)
            {
                Author author = CreateOrLoadAuthor(context, authorName);
                newBook.Authors.Add(author);
            }

            foreach (ReviewTransferObject reviewTransferObject in reviewTransferObjects)
            {
                Review review = SerializeToReview(context, reviewTransferObject);
                newBook.Reviews.Add(review);
            }

            context.Books.Add(newBook);
            context.SaveChanges();
        }

        private Review SerializeToReview(BookstoreEntities context, ReviewTransferObject reviewTransferObject)
        {
            Review review = new Review();
            review.Content = reviewTransferObject.Content;
            string authorName = reviewTransferObject.Author;
            if (authorName != null)
            {
                review.Author = CreateOrLoadAuthor(context, authorName);
            }

            review.DateOfCreation = reviewTransferObject.Date;
            
            return review;
        }

        private Author CreateOrLoadAuthor(BookstoreEntities context, string authorName)
        {
            Author author = context.Authors.FirstOrDefault<Author>(a => a.Name == authorName);
            if (author != null)
            {
                return author;
            }

            Author newAuthor = new Author() { Name = authorName };
            context.Authors.Add(newAuthor);
            context.SaveChanges();

            return newAuthor;
        }

        // Task 5
        public IEnumerable<FoundBookTransferObject> SearchBooks(string title, string author, string isbn)
        {
            BookstoreEntities context = new BookstoreEntities();
            var books = context.Books.Include("Reviews").AsQueryable<Book>();
            if (title != null)
            {
                books = books.Where(b => b.Title.ToLower() == title);
            }

            if (author != null)
            {
                books = books.Where(b => b.Authors.Any(a => a.Name.ToLower() == author));
            }

            if (isbn != null)
            {
                books = books.Where(b => b.ISBN == isbn);
            }

            books = books.OrderBy(b => b.Title);
            IList<FoundBookTransferObject> foundBooksInfos = new List<FoundBookTransferObject>();
            foreach (Book book in books)
            {
                foundBooksInfos.Add(new FoundBookTransferObject()
                    {
                        BookTitle = book.Title,
                        ReviewsCount = book.Reviews.Count
                    });
            }

            return foundBooksInfos;
        }
    }
}
