namespace LaptopListingSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using LaptopListingSystem.Data.Contracts;
    using LaptopListingSystem.Models;

    public class LaptopListingSystemDbContext : IdentityDbContextWithCustomUser<UserProfile>, ILaptopListingSystemDbContext
    {
        public IDbSet<Laptop> Laptops { get; set; }

        public IDbSet<Manufacturer> Manufacturer { get; set; }

        public IDbSet<Vote> Votes { get; set; }

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
