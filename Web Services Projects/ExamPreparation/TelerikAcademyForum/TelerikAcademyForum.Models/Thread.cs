namespace TelerikAcademyForum.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Thread
    {
        public Thread()
        {
            this.Categories = new HashSet<Category>();
            this.Posts = new HashSet<Post>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public virtual User Author { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
