namespace TicketingSystem.Data
{
    using System;
    using System.Collections.Generic;

    using TicketingSystem.Data.Contracts;
    using TicketingSystem.Data.Models;

    public class TicketingSystemData : ITicketingSystemData
    {
        private readonly ITicketingSystemDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public TicketingSystemData(ITicketingSystemDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "An instance of ITicketingSystemDbContext is required.");
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

        public IRepository<Ticket> Tickets
        {
            get { return this.GetRepository<Ticket>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public ITicketingSystemDbContext Context
        {
            get { return this.context; }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
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
