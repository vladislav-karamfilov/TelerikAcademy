namespace CrowdSourcedNews.Data
{
    using System.Data.Entity;
    using CrowdSourcedNews.Models;

    public class CrowdSourcedNewsContext : DbContext
    {
        public CrowdSourcedNewsContext()
            : base("CrowdSourcedNewsDb")
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<NewsArticle> NewsArticles { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
