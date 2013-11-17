namespace TwitterLikeSystem.Data.Contracts
{
    using TwitterLikeSystem.Models;

    public interface IUsersRepository : IRepository<UserProfile>
    {
        UserProfile GetByUsername(string username);
    }
}
