namespace Exam.Data.Contracts
{
    using System;
    using Exam.Models;

    public interface IExamData : IDisposable
    {
        IRepository<UserProfile> Users { get; }

        IRepository<Category> Categories { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<Comment> Comments { get; }

        IExamDbContext Context { get; }

        int SaveChanges();
    }
}
