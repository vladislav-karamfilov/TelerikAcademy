namespace TwitterLikeSystem.Data
{
    using System;
    using System.Collections.Generic;
    using TwitterLikeSystem.Data.Contracts;
    using TwitterLikeSystem.Data.Repositories;
    using TwitterLikeSystem.Models;

    public class TwitterLikeSystemData : ITwitterLikeSystemData
    {
        private readonly ITwitterLikeSystemDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public TwitterLikeSystemData(ITwitterLikeSystemDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "An instance of ITwitterLikeSystemContext is required.");
            }

            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IUsersRepository Users
        {
            get { return (UsersRepository)this.GetRepository<UserProfile>(); }
        }

        public IRepository<Tweet> Tweets
        {
            get { return this.GetRepository<Tweet>(); }
        }

        public IRepository<HashTag> HashTags
        {
            get { return this.GetRepository<HashTag>(); }
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

                if (typeof(T).IsAssignableFrom(typeof(UserProfile)))
                {
                    type = typeof(UsersRepository);
                }

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
