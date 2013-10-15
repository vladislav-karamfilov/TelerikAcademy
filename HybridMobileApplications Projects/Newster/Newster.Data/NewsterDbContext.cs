namespace Newster.Data
{
    using System.Data.Entity;
    using Newster.Data.Contracts;
    using Newster.Models;

    public class NewsterDbContext : DbContext, INewsterDbContext
    {
        public NewsterDbContext()
            : base("NewsterDb")
        { }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<NewsArticle> NewsArticles { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public DbContext DbContext
        {
            get { return this; }
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
