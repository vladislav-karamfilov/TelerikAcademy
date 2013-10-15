namespace Newster.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Newster.Models;

    public interface INewsterDbContext : IDisposable
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<NewsArticle> NewsArticles { get; set; }

        IDbSet<Comment> Comments { get; set; }

        int SaveChanges();

        DbContext DbContext { get; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
