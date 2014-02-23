namespace TicketingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TicketingSystem.Common;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        [MinLength(GlobalConstants.CommentMinLength)]
        [MaxLength(GlobalConstants.CommentMaxLength)]
        public string Content { get; set; }

        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
