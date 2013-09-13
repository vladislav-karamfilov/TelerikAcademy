namespace SchoolsSystem.Repositories
{
    using System.Linq;
    using SchoolsSystem.Models;

    public class InMemoryStudentsRepository : InMemoryRepository<Student>, IStudentsRepository
    {
        public IQueryable<Student> GetBySubjectAndMark(string subject, double mark)
        {
            return this.GetAll().Where(
                st => st.Marks.Any(m => m.Subject == subject && m.Value == mark))
                .AsQueryable<Student>();
        } 
    }
}
