namespace ArticlesSearchFromFeedzillaAPI.Client
{
    using System;

    public class Article
    {
        public DateTime PublishDate { get; set; }

        public string Source { get; set; }

        public string SourceUrl { get; set; }

        public string Summary { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}
