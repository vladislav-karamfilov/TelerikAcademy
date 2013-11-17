namespace Exam.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class UserProfile : User
    {
        public UserProfile()
        {
            this.Points = 10;
        }

        public int Points { get; set; }
    }
}
