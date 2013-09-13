namespace BloggingSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
