namespace Newster.DataTransferObjects
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Newster.Models;

    [DataContract]
    public class NewsArticleDTO
    {
        public static Expression<Func<NewsArticle, NewsArticleDTO>> FromModel
        {
            get
            {
                return newsArticle => new NewsArticleDTO()
                {
                    ID = newsArticle.ID,
                    Date = newsArticle.Date,
                    Title = newsArticle.Title,
                    Category = newsArticle.Category.Name
                };
            }
        }

        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }
    }
}
