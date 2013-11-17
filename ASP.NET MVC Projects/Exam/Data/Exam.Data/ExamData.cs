namespace Exam.Data
{
    using System;
    using System.Collections.Generic;
    using Exam.Data.Contracts;
    using Exam.Models;

    public class ExamData : IExamData
    {
        private readonly IExamDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public ExamData(IExamDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "An instance of IExamDbContext is required.");
            }

            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<UserProfile> Users
        {
            get { return this.GetRepository<UserProfile>(); }
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

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public IExamDbContext Context
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
