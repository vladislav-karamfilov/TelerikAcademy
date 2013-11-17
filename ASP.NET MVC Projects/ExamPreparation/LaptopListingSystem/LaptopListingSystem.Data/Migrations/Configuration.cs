namespace LaptopListingSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LaptopListingSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<LaptopListingSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LaptopListingSystemDbContext context)
        {
            if (context.Laptops.Count() == 0)
            {
                var randomGenerator = new Random();

                var user = new UserProfile()
                {
                    UserName = "TestUser",
                    Email = "test@test.com"
                };

                for (int i = 0; i < 5; i++)
                {
                    var manufacturer = new Manufacturer() { Name = "Manufacturer " + (i + 1) };
                    var laptopsCount = randomGenerator.Next(0, 10);
                    for (int j = 0; j < laptopsCount; j++)
                    {
                        manufacturer.Laptops.Add(new Laptop()
                        {
                            Model = "Model " + (i + 1) + (j + 1),
                            HardDiskCapacity = randomGenerator.Next(256, 4096),
                            ImageUrl = "http://laptop.bg/system/images/25422/normal/ThinkPad_Edge_E530c.png?1376495065",
                            MonitorSize = 15.6,
                            RamCapacity = randomGenerator.Next(1, 32),
                            Price = randomGenerator.Next(500, 5000),
                            Weight = randomGenerator.Next(1, 5)
                        });
                    }

                    context.Manufacturer.Add(manufacturer);
                }

                context.SaveChanges();
            }
        }
    }
}
