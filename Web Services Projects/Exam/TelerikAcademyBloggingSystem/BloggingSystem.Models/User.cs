namespace BloggingSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string AuthCode { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public string SessionKey { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
