namespace CarRentalSystem.Data
{
    using System.Data.Entity;
    using CarRentalSystem.Models;

    public class CarRentalSystemContext : DbContext
    {
        public CarRentalSystemContext()
            : base("CarRentalSystemDB")
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<CarStore> CarStores { get; set; }

        public DbSet<Car> Cars { get; set; }
    }
}
