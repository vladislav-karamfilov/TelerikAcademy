namespace TwitterLikeSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class HashTag
    {
        private ICollection<Tweet> tweets;

        public HashTag()
        {
            this.tweets = new HashSet<Tweet>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Hash tag's name cannot be null or empty!")]
        [RegularExpression(GlobalConstants.HashTagAndTweetRegEx)]
        [MaxLength(GlobalConstants.HashTagAndTweetMaxLength, ErrorMessage = "Hashtag's title cannot be more than {1} characters long!")]
        public string Title { get; set; }

        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        }
    }
}
