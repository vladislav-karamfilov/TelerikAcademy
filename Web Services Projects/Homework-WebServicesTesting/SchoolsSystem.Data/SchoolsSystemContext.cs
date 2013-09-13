namespace SchoolsSystem.Data
{
    using System.Data.Entity;
    using SchoolsSystem.Models;

    public class SchoolsSystemContext : DbContext
    {
        public SchoolsSystemContext()
            : base("SchoolsSystemDB")
        { }

        public DbSet<Student> Students { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<School> Schools { get; set; }
    } 
}
