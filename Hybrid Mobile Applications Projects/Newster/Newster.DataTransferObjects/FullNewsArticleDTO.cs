namespace Newster.DataTransferObjects
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using Newster.Models;

    [DataContract]
    public class FullNewsArticleDTO : VotedNewsArticleDTO
    {
        public static new Expression<Func<NewsArticle, FullNewsArticleDTO>> FromModel
        {
            get
            {
                return newsArticle => new FullNewsArticleDTO()
                {
                    ID = newsArticle.ID,
                    Content = newsArticle.Content,
                    Author = newsArticle.Author != null ? newsArticle.Author.Nickname : "Anonymous",
                    CategoryID = newsArticle.CategoryID,
                    Category = newsArticle.Category.Name,
                    Date = newsArticle.Date,
                    ImageUrl = newsArticle.ImageUrl,
                    Coordinates = new CoordinatesDTO() { Latitude = newsArticle.Coordinates.Latitude, Longitude = newsArticle.Coordinates.Longitude },
                    Title = newsArticle.Title,
                    Votes = newsArticle.Votes
                };
            }
        }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "content")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter news article content...")]
        public string Content { get; set; }

        [DataMember(Name = "categoryId")]
        public int CategoryID { get; set; }

        [DataMember(Name = "coordinates")]
        public CoordinatesDTO Coordinates { get; set; }

        [DataMember(Name = "image")]
        public string ImageUrl { get; set; }
    }
}
