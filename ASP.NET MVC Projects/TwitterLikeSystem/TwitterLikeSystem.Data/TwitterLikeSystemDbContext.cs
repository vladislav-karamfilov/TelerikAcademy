namespace TwitterLikeSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TwitterLikeSystem.Data.Contracts;
    using TwitterLikeSystem.Models;

    public class TwitterLikeSystemDbContext : IdentityDbContextWithCustomUser<UserProfile>, ITwitterLikeSystemDbContext
    {
        public virtual IDbSet<Tweet> Tweets { get; set; }

        public virtual IDbSet<HashTag> HashTags { get; set; }

        public DbContext DbContext
        {
            get { return this; }
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
