namespace Newster.DataTransferObjects
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Newster.Models;

    [DataContract]
    public class FullNewsArticleDTO
    {
        public static Expression<Func<NewsArticle, FullNewsArticleDTO>> FromModel
        {
            get
            {
                return newsArticle => new FullNewsArticleDTO()
                {
                    Content = newsArticle.Content,
                    Author = newsArticle.Author != null ? newsArticle.Author.Nickname : "Anonymous",
                    Category = newsArticle.Category.Name,
                    Date = newsArticle.Date,
                    Place = new CoordinatesDTO() { Latitude = newsArticle.Coordinates.Latitude, Longitude = newsArticle.Coordinates.Longitude },
                    Title = newsArticle.Title,
                    Votes = newsArticle.Votes
                };
            }
        }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "place")]
        public CoordinatesDTO Place { get; set; }

        [DataMember(Name = "votes")]
        public int Votes { get; set; }
    }
}
