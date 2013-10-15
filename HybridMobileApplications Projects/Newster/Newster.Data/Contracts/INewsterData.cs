namespace Newster.Data.Contracts
{
    using System;
    using Newster.Models;

    public interface INewsterData : IDisposable
    {
        IRepository<User> Users { get; }

        IRepository<Category> Categories { get; }

        IRepository<NewsArticle> NewsArticles { get; }

        IRepository<Comment> Comments { get; }

        INewsterDbContext Context { get; }

        int SaveChanges();
    }
}
