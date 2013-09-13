namespace TelerikAcademyForum.Data
{
    using System.Data.Entity;
    using TelerikAcademyForum.Models;

    public class TelerikAcademyForumContext : DbContext
    {
        public TelerikAcademyForumContext()
            : base("TelerikAcademyForumDb")
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Thread> Threads { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Vote> Votes { get; set; }
    }
}
