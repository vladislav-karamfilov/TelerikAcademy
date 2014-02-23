namespace TicketingSystem.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using TicketingSystem.Data.Models;

    public interface ITicketingSystemDbContext : IDisposable
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<Ticket> Tickets { get; set; }

        IDbSet<Comment> Comments { get; set; }

        DbContext DbContext { get; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
