namespace TwitterLikeSystem.Data.Repositories
{
    using System.Linq;
    using TwitterLikeSystem.Data.Contracts;
    using TwitterLikeSystem.Models;

    public class UsersRepository : DbRepository<UserProfile>, IUsersRepository
    {
        public UsersRepository(ITwitterLikeSystemDbContext context)
            : base(context)
        { }

        public UserProfile GetByUsername(string username)
        {
            return this.All().FirstOrDefault(u => u.UserName == username);
        }
    }
}
