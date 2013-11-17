namespace LaptopListingSystem.Data
{
    using LaptopListingSystem.Data.Contracts;
    using LaptopListingSystem.Models;
    using System;
    using System.Collections.Generic;

    public class LaptopListingSystemData : ILaptopListingSystemData
    {
        private readonly ILaptopListingSystemDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public LaptopListingSystemData(ILaptopListingSystemDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "An instance of ILaptopListingSystemDbContext is required.");
            }

            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<UserProfile> Users
        {
            get { return this.GetRepository<UserProfile>(); }
        }

        public ILaptopsRepository Laptops
        {
            get { return (LaptopsRepository)this.GetRepository<Laptop>(); }
        }

        public IRepository<Manufacturer> Manufacturers
        {
            get { return this.GetRepository<Manufacturer>(); }
        }

        public IRepository<Vote> Votes
        {
            get { return this.GetRepository<Vote>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
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

                if (typeof(T).IsAssignableFrom(typeof(Laptop)))
                {
                    type = typeof(LaptopsRepository);
                }

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
