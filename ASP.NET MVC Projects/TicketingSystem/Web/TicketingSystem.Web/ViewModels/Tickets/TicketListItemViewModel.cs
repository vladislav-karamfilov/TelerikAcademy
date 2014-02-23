namespace TicketingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Linq.Expressions;

    using TicketingSystem.Common.Extensions;
    using TicketingSystem.Data.Models;

    public class TicketListItemViewModel
    {
        public static Expression<Func<Ticket, TicketListItemViewModel>> ViewModel
        {
            get
            {
                return x =>
                    new TicketListItemViewModel
                    {
                        Id = x.Id,
                        Author = x.Author.UserName,
                        CategoryId = x.CategoryId,
                        Category = x.Category.Name,
                        Title = x.Title,
                        PriorityId = x.Priority
                    };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public Priority PriorityId { get; set; }

        public string Priority
        {
            get
            {
                return this.PriorityId.GetDescription();
            }
        }
    }
}