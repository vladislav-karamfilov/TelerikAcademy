namespace Bookstore.Logs.Data
{
    using System.Data.Entity;
    using Bookstore.Logs.Models;

    public class LogsContext : DbContext
    {
        public LogsContext()
            : base("Logs")
        {
        }

        public DbSet<SearchLog> SearchLogs { get; set; }
    }
}
