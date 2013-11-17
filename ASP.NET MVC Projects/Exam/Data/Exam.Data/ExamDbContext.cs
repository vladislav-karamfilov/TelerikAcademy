namespace Exam.Data
{
    using System.Data.Entity;
    using Exam.Data.Contracts;
    using Exam.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ExamDbContext : IdentityDbContextWithCustomUser<UserProfile>, IExamDbContext
    {
        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Ticket> Tickets { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public DbContext DbContext
        {
            get { return this; }
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
