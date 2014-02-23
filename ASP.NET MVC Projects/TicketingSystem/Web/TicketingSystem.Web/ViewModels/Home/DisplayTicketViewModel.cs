namespace TicketingSystem.Web.ViewModels.Home
{
    using System;
    using System.Linq.Expressions;
    
    using TicketingSystem.Data.Models;

    public class DisplayTicketViewModel
    {
        public static Expression<Func<Ticket, DisplayTicketViewModel>> ViewModel
        {
            get
            {
                return ticket => new DisplayTicketViewModel
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Author = ticket.Author.UserName,
                    Category = ticket.Category.Name,
                    CommentsCount = ticket.Comments.Count
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public int CommentsCount { get; set; }
    }
}