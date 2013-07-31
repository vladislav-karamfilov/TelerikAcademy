namespace Supermarket.Data
{
    using System.Data.Entity;
    using Supermarket.Models;

    public class SupermarketContext : DbContext
    {
        public SupermarketContext()
            : base("SupermarketDB")
        {
        }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<SupermarketBranch> Supermarkets { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Expense> Expenses { get; set; }
    }
}
