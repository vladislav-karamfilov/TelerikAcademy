namespace Exam.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual UserProfile Author { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        public int TicketId { get; set; }

        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }
    }
}
