namespace Newster.Data
{
    using System;
    using System.Collections.Generic;
    using Newster.Data.Contracts;
    using Newster.Models;

    public class NewsterData : INewsterData
    {
        private readonly INewsterDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public NewsterData(INewsterDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "An instance of INewsterDbContext is required.");
            }

            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<NewsArticle> NewsArticles
        {
            get { return this.GetRepository<NewsArticle>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public INewsterDbContext Context
        {
            get { return this.context; }
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DbRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
