namespace Exam.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Exam.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ExamDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ExamDbContext context)
        {
            if (!context.Tickets.Any())
            {
                var testUser = new UserProfile() { UserName = "TestUser" };
                context.Users.Add(testUser);
                context.SaveChanges();

                Random rand = new Random();
                var categoriesCount = 7;
                for (int i = 0; i < categoriesCount; i++)
                {
                    var category = new Category() { Name = "Category" + i };

                    var ticketsCount = rand.Next(10);
                    for (int j = 0; j < ticketsCount; j++)
                    {
                        var ticket = new Ticket()
                        {
                            AuthorId = testUser.Id,
                            Description = (rand.Next(10000) % 2 == 0) ? ("Description " + rand.Next(1000)) : null,
                            Priority = (Priority)rand.Next(3),
                            ScreenshotUrl = (rand.Next(10000) % 2 == 1) ? "http://acrowdofmonsters.com/wp-content/uploads/bugs.jpg" : null,
                            Title = "Title " + rand.Next(100),
                            CategoryId = category.Id
                        };

                        category.Tickets.Add(ticket);

                        var commentsCount = rand.Next(5);
                        for (int k = 0; k < commentsCount; k++)
                        {
                            var comment = new Comment()
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
