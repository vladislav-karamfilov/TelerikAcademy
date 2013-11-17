namespace LaptopListingSystem.Data.Contracts
{
using System.Linq;
    using LaptopListingSystem.Models;

    public interface ILaptopsRepository :  IRepository<Laptop>
    {
        IQueryable<Laptop> GetTopLaptopsByTotalVotes(int count);
    }
}
