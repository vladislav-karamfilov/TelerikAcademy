namespace CarRentalSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class CarRentalSystemContextFactory : IDbContextFactory<DbContext>
    {
        public DbContext Create()
        {
            return new CarRentalSystemContext();
        }
    }
}
