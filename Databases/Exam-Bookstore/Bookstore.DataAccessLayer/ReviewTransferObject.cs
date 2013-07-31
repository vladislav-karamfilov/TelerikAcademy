namespace Bookstore.DataAccessLayer
{
    using System;

    public class ReviewTransferObject
    {
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string Author { get; set; }
    }
}
