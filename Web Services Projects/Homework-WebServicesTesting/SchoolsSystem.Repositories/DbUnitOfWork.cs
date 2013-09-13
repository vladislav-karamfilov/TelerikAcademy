namespace SchoolsSystem.Repositories
{
    using SchoolsSystem.Data;
    using SchoolsSystem.Models;
    using System;

    public class DbUnitOfWork : IUnitOfWork
    {
        private SchoolsSystemContext context;
        private IStudentsRepository studentsRepository;
        private IRepository<School> schoolsRepository;
        private IRepository<Mark> marksRepository;

        private bool isDisposed;

        public DbUnitOfWork()
        {
            this.context = new SchoolsSystemContext();
            this.studentsRepository = new DbStudentsRepository(context);
            this.schoolsRepository = new DbRepository<School>(context);
            this.marksRepository = new DbRepository<Mark>(context);

            this.isDisposed = false;
        }

        public IStudentsRepository StudentsRepository
        {
            get { return this.studentsRepository; }
        }

        public IRepository<School> SchoolsRepository
        {
            get { return this.schoolsRepository; }
        }

        public IRepository<Mark> MarksRepository
        {
            get { return this.marksRepository; }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed && disposing)
            {
                context.Dispose();
            }

            this.isDisposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
