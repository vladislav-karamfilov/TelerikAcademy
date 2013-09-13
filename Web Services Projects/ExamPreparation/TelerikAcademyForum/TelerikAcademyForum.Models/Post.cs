namespace TelerikAcademyForum.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post
    {
        public Post()
        {
            this.Votes = new HashSet<Vote>();
            this.Comments = new List<Comment>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PostDate { get; set; }

        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public virtual User Author { get; set; }

        public int? ThreadID { get; set; }

        [ForeignKey("ThreadID")]
        public virtual Thread Thread { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
