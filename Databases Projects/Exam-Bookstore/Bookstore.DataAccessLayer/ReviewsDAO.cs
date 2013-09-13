namespace Bookstore.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bookstore.Data;

    public class ReviewsDAO
    {
        // Task 6
        public IEnumerable<FoundReviewTransferObject> GetReviewsByPeriod(DateTime starDate, DateTime endDate)
        {
            BookstoreEntities context = new BookstoreEntities();
            var reviewsInPeriod = context.Reviews.Include("Book").Include("Book.Authors")
                .Where(r => r.DateOfCreation.CompareTo(starDate) >= 0 &&
                    r.DateOfCreation.CompareTo(endDate) <= 0)
                .OrderBy(r => r.DateOfCreation).ThenBy(r => r.Content);

            IList<FoundReviewTransferObject> reviewsFound = new List<FoundReviewTransferObject>();
            DeserializeFoundReviews(reviewsInPeriod, reviewsFound);

            return reviewsFound;
        }

        // Task 6
        public IEnumerable<FoundReviewTransferObject> GetReviewsByAuthorName(string authorName)
        {
            BookstoreEntities context = new BookstoreEntities();
            var reviewsInPeriod = context.Reviews.Include("Book").Include("Book.Authors")
                .Where(r => r.Author.Name.ToLower() == authorName)
                .OrderBy(r => r.DateOfCreation).ThenBy(r => r.Content);

            IList<FoundReviewTransferObject> reviewsFound = new List<FoundReviewTransferObject>();
            DeserializeFoundReviews(reviewsInPeriod, reviewsFound);

            return reviewsFound;
        }

        private void DeserializeFoundReviews(IOrderedQueryable<Review> reviewsInPeriod, IList<FoundReviewTransferObject> reviewsFound)
        {
            foreach (Review review in reviewsInPeriod)
            {
                FoundReviewTransferObject foundReview = new FoundReviewTransferObject();
                foundReview.Date = review.DateOfCreation;
                foundReview.Content = review.Content;
                foundReview.BookTitle = review.Book.Title;
                foundReview.BookIsbn = review.Book.ISBN;
                foundReview.BookUrl = review.Book.WebSite;
                if (review.Book.Authors.Count != 0)
                {
                    var authorNames = review.Book.Authors
                        .OrderBy(a => a.Name).Select(a => a.Name);

                    foundReview.BookAuthors = string.Join(", ", authorNames);
                }

                reviewsFound.Add(foundReview);
            }
        }
    }
}
