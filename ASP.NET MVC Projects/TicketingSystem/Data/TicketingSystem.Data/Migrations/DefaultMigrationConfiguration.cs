namespace TicketingSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    using TicketingSystem.Common;
    using TicketingSystem.Data.Models;

    public sealed class DefaultMigrationConfiguration : DbMigrationsConfiguration<TicketingSystemDbContext>
    {
        public DefaultMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TicketingSystemDbContext context)
        {
            if (!context.Tickets.Any())
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));
                var testUser = new User("TestUser");
                userManager.Create(testUser, "test123");

                var administratorRole = new IdentityRole(GlobalConstants.AdministratorRoleName);
                var testUserInAdministrationRole = new IdentityUserRole { Role = administratorRole, User = testUser };
                testUser.Roles.Add(testUserInAdministrationRole);

                context.SaveChanges();

                var rand = RandomGenerator.Instance;
                var categoriesCount = rand.Next(7, 11);
                for (var i = 0; i < categoriesCount; i++)
                {
                    var category = new Category { Name = "Category " + i };

                    var ticketsCount = rand.Next(10);
                    for (var j = 0; j < ticketsCount; j++)
                    {
                        var ticket = new Ticket
                        {
                            AuthorId = testUser.Id,
                            Description = (rand.Next(10000) % 2 == 0) ? ("Description " + rand.Next(1000)) : null,
                            Priority = (Priority)rand.Next(1, 4),
                            ScreenshotUrl = (rand.Next(10000) % 2 == 1) ? "http://acrowdofmonsters.com/wp-content/uploads/bugs.jpg" : null,
                            Title = "Title " + rand.Next(100),
                            CategoryId = category.Id
                        };

                        category.Tickets.Add(ticket);

                        var commentsCount = rand.Next(5);
                        for (var k = 0; k < commentsCount; k++)
                        {
                            var comment = new Comment
                            {
                                AuthorId = testUser.Id,
                                Content = "Comment " + rand.Next(2000),
                                TicketId = ticket.Id
                            };

                            ticket.Comments.Add(comment);
                        }
                    }

                    context.Categories.Add(category);
                }

                context.SaveChanges();
            }
        }
    }
}
