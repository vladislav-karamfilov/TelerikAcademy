namespace TwitterLikeSystem.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using TwitterLikeSystem.Models;

    public interface ITwitterLikeSystemDbContext : IDisposable
    {
        IDbSet<Tweet> Tweets { get; set; }

        IDbSet<HashTag> HashTags { get; set; }

        int SaveChanges();

        DbContext DbContext { get; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
