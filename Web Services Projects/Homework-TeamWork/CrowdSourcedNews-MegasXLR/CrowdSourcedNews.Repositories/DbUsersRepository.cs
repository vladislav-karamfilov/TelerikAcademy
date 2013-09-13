namespace CrowdSourcedNews.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using CrowdSourcedNews.Models;

    public class DbUsersRepository : DbRepository<User>
    {
        public DbUsersRepository(DbContext context)
            : base(context)
        { }

        public User GetByNickname(string nickname)
        {
            return this.GetAll().First<User>(u => u.Nickname == nickname);
        }

        public User GetByUsernameAndAuthCode(string username, string authCode)
        {
            return this.GetAll().First<User>(u => u.Username == username && u.AuthCode == authCode);
        }

        public User GetBySessionKey(string sessionKey)
        {
            return this.GetAll().First<User>(u => u.SessionKey == sessionKey);
        }
    }
}
