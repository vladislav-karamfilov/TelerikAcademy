namespace TicketingSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    using TicketingSystem.Common;
    using TicketingSystem.Common.ValidationAttributes;

    public class Ticket
    {
        private ICollection<Comment> comments;

        public Ticket()
        {
            this.Priority = Priority.Medium;
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        [MinLength(GlobalConstants.TicketTitleMinLength)]
        [MaxLength(GlobalConstants.TicketTitleMaxLength)]
        [DoesNotContainBugWord]
        public string Title { get; set; }

        public Priority Priority { get; set; }

        [RegularExpression(GlobalConstants.UrlRegEx)]
        public string ScreenshotUrl { get; set; }

        [MinLength(GlobalConstants.TicketDescriptionMinLength)]
        [MaxLength(GlobalConstants.TicketDescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
