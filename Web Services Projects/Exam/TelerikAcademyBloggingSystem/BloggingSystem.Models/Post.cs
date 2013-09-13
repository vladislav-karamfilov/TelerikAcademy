namespace BloggingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Tags = new HashSet<Tag>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public virtual User Author { get; set; }

        public DateTime PostDate { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
