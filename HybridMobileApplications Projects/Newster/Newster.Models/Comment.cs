namespace Newster.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        [Key, Column("CommentID")]
        public int ID { get; set; }

        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public virtual User Author { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public int NewsArticleID { get; set; }

        [ForeignKey("NewsArticleID")]
        public virtual NewsArticle NewsArticle { get; set; }
    }
}
