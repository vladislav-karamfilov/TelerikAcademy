namespace TelerikAcademyForum.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Threads = new HashSet<Thread>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }
    }
}
