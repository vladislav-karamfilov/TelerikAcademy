namespace LaptopListingSystem.Data.Contracts
{
    using System;
    using LaptopListingSystem.Models;

    public interface ILaptopListingSystemData : IDisposable
    {
        IRepository<UserProfile> Users { get; }

        ILaptopsRepository Laptops { get; }

        IRepository<Manufacturer> Manufacturers { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Vote> Votes { get; }

        int SaveChanges();
    }
}
