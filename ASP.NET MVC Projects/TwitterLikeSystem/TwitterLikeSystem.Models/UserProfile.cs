namespace TwitterLikeSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    public class UserProfile : User
    {
        private ICollection<Tweet> tweets;

        public UserProfile()
        {
            this.tweets = new HashSet<Tweet>();
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "User's first name cannot be null or empty!")]
        [StringLength(
            GlobalConstants.NameMaxLength, 
            ErrorMessage = "User's first name must be between {2} and {1} characters long!", 
            MinimumLength = GlobalConstants.NameMinLength)]
        [RegularExpression(GlobalConstants.NameRegEx)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "User's last name cannot be null or empty!")]
        [StringLength(
            GlobalConstants.NameMaxLength, 
            ErrorMessage = "User's last name must be between {2} and {1} characters long!", 
            MinimumLength = GlobalConstants.NameMinLength)]
        [RegularExpression(GlobalConstants.NameRegEx)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "User's e-mail cannot be null or empty!")]
        [StringLength(
            GlobalConstants.EmailMaxLength,
            ErrorMessage = "User's e-mail cannot be more than {1} characters long!")]
        [RegularExpression(GlobalConstants.EmailRegEx)]
        public string Email { get; set; }

        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        }
    }
}
