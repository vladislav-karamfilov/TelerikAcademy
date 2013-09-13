namespace SchoolsSystem.Repositories
{
    using System;
    using SchoolsSystem.Models;

    public interface IUnitOfWork : IDisposable
    {
        IStudentsRepository StudentsRepository { get; }

        IRepository<School> SchoolsRepository { get; }

        IRepository<Mark> MarksRepository { get; }

        void Save();
    }
}
