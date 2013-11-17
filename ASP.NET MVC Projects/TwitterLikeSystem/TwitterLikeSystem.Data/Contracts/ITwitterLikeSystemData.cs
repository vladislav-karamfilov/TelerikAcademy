namespace TwitterLikeSystem.Data.Contracts
{
    using System;
    using TwitterLikeSystem.Models;

    public interface ITwitterLikeSystemData : IDisposable
    {
        IUsersRepository Users { get; }

        IRepository<Tweet> Tweets { get; }

        IRepository<HashTag> HashTags { get; }

        int SaveChanges();
    }
}
