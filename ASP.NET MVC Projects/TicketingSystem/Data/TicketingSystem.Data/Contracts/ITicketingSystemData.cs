namespace TicketingSystem.Data.Contracts
{
    using System;
    using TicketingSystem.Data.Models;

    public interface ITicketingSystemData : IDisposable
    {
        IRepository<User> Users { get; }

        IRepository<Category> Categories { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<Comment> Comments { get; }

        ITicketingSystemDbContext Context { get; }

        int SaveChanges();
    }
}
