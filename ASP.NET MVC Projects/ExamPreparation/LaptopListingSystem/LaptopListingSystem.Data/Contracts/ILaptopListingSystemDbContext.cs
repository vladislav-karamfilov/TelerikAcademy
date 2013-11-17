namespace LaptopListingSystem.Data.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using LaptopListingSystem.Models;

    public interface ILaptopListingSystemDbContext : IDisposable
    {
        IDbSet<Laptop> Laptops { get; set; }

        IDbSet<Manufacturer> Manufacturer { get; set; }

        IDbSet<Vote> Votes { get; set; }

        IDbSet<Comment> Comments { get; set; }

        int SaveChanges();

        DbContext DbContext { get; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
