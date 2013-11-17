namespace Exam.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Exam.Models.ValidationAttributes;

    public class Ticket
    {
        private ICollection<Comment> comments;

        public Ticket()
        {
            this.Priority = Priority.Medium;
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual UserProfile Author { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DoesNotContainBugWord]
        public string Title { get; set; }

        [EnumDataType(typeof(Priority))]
        public Priority Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
