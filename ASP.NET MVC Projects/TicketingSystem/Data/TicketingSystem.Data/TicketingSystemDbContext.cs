namespace TicketingSystem.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Data.Models;

    public class TicketingSystemDbContext : IdentityDbContext<User>, ITicketingSystemDbContext
    {
        public TicketingSystemDbContext()
            : this("DefaultConnection")
        {
        }

        public TicketingSystemDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

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
