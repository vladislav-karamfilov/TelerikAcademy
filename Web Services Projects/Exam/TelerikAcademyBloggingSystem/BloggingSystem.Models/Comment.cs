namespace BloggingSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Text { get; set; }

        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public virtual User Author { get; set; }

        public DateTime PostDate { get; set; }

        public int? PostID { get; set; }

        [ForeignKey("PostID")]
        public virtual Post Post { get; set; }
    }
}
