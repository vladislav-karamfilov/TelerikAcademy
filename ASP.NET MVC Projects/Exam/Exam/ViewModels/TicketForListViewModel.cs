namespace Exam.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Exam.Models;

    public class TicketForListViewModel
    {
        private int priorityToShowId = 1;

        public static Expression<Func<Ticket, TicketForListViewModel>> FromModel
        {
            get
            {
                return ticket => new TicketForListViewModel()
                {
                    Id = ticket.Id,
                    priorityToShowId = (int)ticket.Priority,
                    Category = ticket.Category.Name,
                    CategoryId = ticket.CategoryId,
                    Author = ticket.Author.UserName,
                    Title = ticket.Title
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public string Priority
        {
            get { return Enum.GetName(typeof(Priority), this.priorityToShowId); }
        }
    }
}