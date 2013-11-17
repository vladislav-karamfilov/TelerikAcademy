namespace TwitterLikeSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tweet
    {
        private ICollection<HashTag> hashTags;

        public Tweet()
        {
            this.hashTags = new HashSet<HashTag>();
        }

        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Tweet's content cannot be null or empty!")]
        [MaxLength(GlobalConstants.HashTagAndTweetMaxLength, ErrorMessage = "Tweet's content cannot be more than {1} characters long!")]
        [RegularExpression(GlobalConstants.HashTagAndTweetRegEx)]
        public string Content { get; set; }

        public bool IsPrivate { get; set; }

        [Required(ErrorMessage = "Tweet must have an author!")]
        public string AuthorId { get; set; }

        public DateTime DatePubished { get; set; }

        [ForeignKey("AuthorId")]
        public virtual UserProfile Author { get; set; }

        public virtual ICollection<HashTag> HashTags
        {
            get { return this.hashTags; }
            set { this.hashTags = value; }
        }
    }
}
