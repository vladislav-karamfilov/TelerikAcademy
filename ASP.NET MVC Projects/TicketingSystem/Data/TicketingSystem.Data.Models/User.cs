namespace TicketingSystem.Data.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        public User()
            : this(string.Empty)
        {
        }

        public User(string username)
            : base(username)
        {
            this.Points = 10;
        }

        public int Points { get; set; }
    }
}
