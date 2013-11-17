namespace Exam.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Exam.Models;

    public interface IExamDbContext : IDisposable
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<Ticket> Tickets { get; set; }

        IDbSet<Comment> Comments { get; set; }

        int SaveChanges();

        DbContext DbContext { get; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
