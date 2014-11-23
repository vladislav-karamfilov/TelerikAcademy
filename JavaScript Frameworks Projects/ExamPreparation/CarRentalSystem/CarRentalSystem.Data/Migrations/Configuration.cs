namespace CarRentalSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CarRentalSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<CarRentalSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarRentalSystemContext context)
        {
            if (!context.Cars.Any())
            {
                var randomGenerator = new Random();
                var carStoresCount = randomGenerator.Next(3, 7);
                this.SeedCarStores(context, carStoresCount, randomGenerator);

                this.SeedCars(context, carStoresCount, randomGenerator);
            }
        }

        private void SeedCarStores(CarRentalSystemContext context, int carStoresCount, Random randomGenerator)
        {
            for (var i = 0; i < carStoresCount; i++)
            {
                context.CarStores.Add(new CarStore
                {
                    Name = "Test car store #" + (i + 1),
                    Latitude = randomGenerator.NextDouble() * randomGenerator.Next(1, 300),
                    Longitude = randomGenerator.NextDouble() * randomGenerator.Next(1, 200)
                });
            }

            context.SaveChanges();
        }

        private void SeedCars(CarRentalSystemContext context, int carStoresCount, Random randomGenerator)
        {
            for (var i = 1; i < carStoresCount; i++)
            {
                var carsCount = randomGenerator.Next(5);

                for (var j = 0; j < carsCount; j++)
                {
                    context.Cars.Add(new Car
                    {
                        CarStoreID = i,
                        Engine = "Test Engine " + randomGenerator.Next(1, 3),
                        Make = "Test Make" + randomGenerator.Next(1, 5),
                        Model = "Test Model" + randomGenerator.Next(1, 10),
                        Power = randomGenerator.Next(100, 500),
                        Year = randomGenerator.Next(1995, 2014)
                    });
                }
            }

            context.SaveChanges();
        }
    }
}
