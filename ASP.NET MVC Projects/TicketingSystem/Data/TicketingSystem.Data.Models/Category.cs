namespace TicketingSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    using TicketingSystem.Common;

    public class Category
    {
        private ICollection<Ticket> tickets;

        public Category()
        {
            this.tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.CategoryNameMinLength)]
        [MaxLength(GlobalConstants.CategoryNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets
        {
            get { return this.tickets; }
            set { this.tickets = value; }
        }
    }
}