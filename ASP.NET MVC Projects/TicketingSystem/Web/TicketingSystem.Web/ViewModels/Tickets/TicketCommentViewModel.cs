namespace TicketingSystem.Web.ViewModels.Tickets
{
    using System;
    using System.Linq.Expressions;

    using TicketingSystem.Data.Models;

    public class TicketCommentViewModel
    {
        public static Expression<Func<Comment, TicketCommentViewModel>> ViewModel
        {
            get
            {
                return x =>
                    new TicketCommentViewModel
                    {
                        Author = x.Author.UserName,
                        Content = x.Content
                    };
            }
        }

        public string Author { get; set; }

        public string Content { get; set; }
    }
}