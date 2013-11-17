namespace LaptopListingSystem.Data
{
    using System;
    using System.Linq;
    using LaptopListingSystem.Data.Contracts;
    using LaptopListingSystem.Models;

    public class LaptopsRepository : DbRepository<Laptop>, ILaptopsRepository
    {
        public LaptopsRepository(ILaptopListingSystemDbContext context)
            : base(context)
        { }

        public IQueryable<Laptop> GetTopLaptopsByTotalVotes(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "The count to top laptops to get cannot be negative!");
            }

            return this.All().OrderByDescending(l => l.Votes.Count).Take(count);
        }
    }
}
