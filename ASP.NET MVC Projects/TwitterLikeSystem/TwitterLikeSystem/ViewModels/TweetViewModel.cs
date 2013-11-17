namespace TwitterLikeSystem.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using TwitterLikeSystem.Models;

    public class TweetViewModel
    {
        public static Expression<Func<Tweet, TweetViewModel>> FromModel
        {
            get
            {
                return tweet => new TweetViewModel()
                {
                    Author = tweet.Author.FirstName + " " + tweet.Author.LastName,
                    Content = tweet.Content,
                    DatePublished = tweet.DatePubished,
                    IsPrivate = tweet.IsPrivate
                };
            }
        }

        [Required(AllowEmptyStrings = false)]
        public string Author { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatePublished { get; set; }

        [Required(ErrorMessage = "Please enter content")]
        [MaxLength(GlobalConstants.HashTagAndTweetMaxLength,
            ErrorMessage = "Tweet's content cannot be more than {1} characters long!")]
        [RegularExpression(GlobalConstants.HashTagAndTweetRegEx)]
        public string Content { get; set; }

        public bool IsPrivate { get; set; }
    }
}
