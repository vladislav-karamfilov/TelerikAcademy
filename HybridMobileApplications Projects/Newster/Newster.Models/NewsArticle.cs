namespace Newster.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class NewsArticle
    {
        private ICollection<Comment> comments;

        public NewsArticle()
        {
            this.comments = new List<Comment>();
        }

        [Key, Column("NewsArticleID")]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        public int? AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public virtual User Author { get; set; }

        public DateTime Date { get; set; }

        public int Votes { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public int? CoordinatesID { get; set; }

        [ForeignKey("CoordinatesID")]
        public virtual Coordinates Coordinates { get; set; }
    }
}
