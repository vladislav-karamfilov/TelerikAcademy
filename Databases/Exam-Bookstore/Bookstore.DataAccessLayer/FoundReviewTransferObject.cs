namespace Bookstore.DataAccessLayer
{
    using System;

    public class FoundReviewTransferObject
    {
        public DateTime? Date { get; set; }

        public string Content { get; set; }

        public string BookTitle { get; set; }

        public string BookAuthors { get; set; }

        public string BookIsbn { get; set; }

        public string BookUrl { get; set; }
    }
}
