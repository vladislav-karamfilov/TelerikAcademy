namespace TelerikAcademyForum.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Threads = new HashSet<Thread>();
            this.Posts = new HashSet<Post>();
            this.Votes = new HashSet<Vote>();
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string AuthCode { get; set; }

        [Required]
        public string Nickname { get; set; }

        public string SessionKey { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
