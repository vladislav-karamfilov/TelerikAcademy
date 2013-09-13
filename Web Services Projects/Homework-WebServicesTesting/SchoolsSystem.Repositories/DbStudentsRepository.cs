namespace SchoolsSystem.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using SchoolsSystem.Models;

    public class DbStudentsRepository : DbRepository<Student>, IStudentsRepository
    {
        public DbStudentsRepository(DbContext context)
            : base(context)
        { }

        public IQueryable<Student> GetBySubjectAndMark(string subject, double mark)
        {
            return this.GetAll()
                .Where(st => st.Marks.Any(m => m.Subject == subject && m.Value > mark))
                .AsQueryable<Student>();
        }
    }
}
