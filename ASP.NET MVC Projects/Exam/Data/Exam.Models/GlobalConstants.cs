namespace Exam.Models
{
    public class GlobalConstants
    {
        // Username constants
        public const int UsernameMinLength = 6;
        public const int UsernameMaxLength = 16;
        public const string UsernameRegEx = @"^[a-zA-Z]([/._]?[a-zA-Z0-9]+)+$";

        // Password constants
        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 1000;

        // URL constants
        public const string UrlRegEx = "^(http|https)?(\\://)?(www\\.)?[a-zA-Z0-9\\-\\.]+\\.[a-zA-Z]{2,4}(/\\S*)?$";
    }
}