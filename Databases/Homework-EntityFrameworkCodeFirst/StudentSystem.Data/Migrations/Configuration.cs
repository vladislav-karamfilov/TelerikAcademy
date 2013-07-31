namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );

            Course databaseCourse = new Course() { Name = "Databases", Description = "Telerik Academy Databases course" };
            Course oopCourse = new Course() { Name = "OOP", Description = "Telerik Academy OOP course" };

            Student kiroStudent = new Student() { Name = "Kiro", FacultyNumber = "11111111" };
            Student mitkoStudent = new Student() { Name = "Mitko", FacultyNumber = "22222222" };
            Student peshoStudent = new Student() { Name = "Pesho", FacultyNumber = "33333333" };

            databaseCourse.Students.Add(peshoStudent);
            databaseCourse.Students.Add(mitkoStudent);
            databaseCourse.Materials.Add(new Material() { Name = "Entity Framework Presentation" });
            databaseCourse.Materials.Add(new Material() { Name = "Entity Framework Demo" });

            oopCourse.Students.Add(kiroStudent);
            oopCourse.Students.Add(mitkoStudent);
            oopCourse.Materials.Add(new Material() { Name = "Defining Classes Presentation" });
            oopCourse.Materials.Add(new Material() { Name = "Defining Classes Demo" });

            context.Courses.AddOrUpdate(c => c.Name, databaseCourse);
            context.Courses.AddOrUpdate(c => c.Name, oopCourse);

            context.SaveChanges();
        }
    }
}
