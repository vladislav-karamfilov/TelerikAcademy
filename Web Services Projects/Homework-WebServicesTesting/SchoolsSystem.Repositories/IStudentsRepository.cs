namespace SchoolsSystem.Repositories
{
    using System.Linq;
    using SchoolsSystem.Models;

    public interface IStudentsRepository : IRepository<Student>
    {
        IQueryable<Student> GetBySubjectAndMark(string subject, double mark);
    }
}
