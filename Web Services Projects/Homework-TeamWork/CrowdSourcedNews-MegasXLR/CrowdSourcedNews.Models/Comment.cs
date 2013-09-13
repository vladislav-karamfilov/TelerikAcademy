namespace CrowdSourcedNews.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        [Key, Column("CommentID")]
        public int ID { get; set; }

        public int AuthorID { get; set; }

        [Required, ForeignKey("AuthorID")]
        public virtual User Author { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Date { get; set; }
    }
}