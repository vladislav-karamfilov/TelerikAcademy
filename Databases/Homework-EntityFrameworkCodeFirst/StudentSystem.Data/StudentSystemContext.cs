namespace StudentSystem.Data
{
    using System.Data.Entity;
    using StudentSystem.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentSystemDB")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Material> Materials { get; set; }
    }
}
