namespace CrowdSourcedNews.Services.DependencyResolvers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Web.Http.Dependencies;
    using CrowdSourcedNews.Models;
    using CrowdSourcedNews.Repositories;
    using CrowdSourcedNews.Services.Controllers;

    public class DbDependencyResolver : IDependencyResolver
    {
        private DbContext context;
        private DbUsersRepository usersRepository;
        private IRepository<NewsArticle> newsArticlesRepository;
        private IRepository<Comment> commentsRepository;

        public DbDependencyResolver(DbContext context)
        {
            this.context = context;
            this.usersRepository = new DbUsersRepository(context);
            this.newsArticlesRepository = new DbRepository<NewsArticle>(context);
            this.commentsRepository = new DbRepository<Comment>(context);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(UsersController))
            {
                return new UsersController(
                    usersRepository, newsArticlesRepository, commentsRepository);
            }
            else if (serviceType == typeof(NewsArticlesController))
            {
                return new NewsArticlesController(
                    newsArticlesRepository, usersRepository, commentsRepository);
            }
            else if (serviceType == typeof(CommentsController))
            {
                return new CommentsController(
                    commentsRepository, newsArticlesRepository, usersRepository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose() { }
    }
}