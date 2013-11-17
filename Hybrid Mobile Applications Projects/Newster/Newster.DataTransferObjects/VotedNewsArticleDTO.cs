namespace Newster.DataTransferObjects
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Newster.Models;

    [DataContract]
    public class VotedNewsArticleDTO : NewsArticleDTO
    {
        public static new Expression<Func<NewsArticle, VotedNewsArticleDTO>> FromModel
        {
            get
            {
                return newsArticle => new VotedNewsArticleDTO()
                {
                    ID = newsArticle.ID,
                    Date = newsArticle.Date,
                    Title = newsArticle.Title,
                    Category = newsArticle.Category.Name,
                    Votes = newsArticle.Votes
                };
            }
        }

        [DataMember(Name = "votes")]
        public int Votes { get; set; }
    }
}
