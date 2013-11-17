namespace TwitterLikeSystem.Models
{
    internal class GlobalConstants
    {
        // Username constants
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 32;
        public const string UsernameRegEx = @"^[a-zA-Z]([/._]?[a-zA-Z0-9]+)+$";

        // Password constants
        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 1000;

        // E-mail constants
        public const int EmailMaxLength = 50;
        public const string EmailRegEx = "^[A-Za-z0-9]+[\\._A-Za-z0-9-]+@([A-Za-z0-9]+[-\\.]?[A-Za-z0-9]+)+(\\.[A-Za-z0-9]+[-\\.]?[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";

        // User names constants
        public const int NameMinLength = 2;
        public const int NameMaxLength = 30;
        public const string NameRegEx = @"^$|^[a-zA-Zа-яА-Я]{1,}[-]?[a-zA-Zа-яА-Я]{1,}$";

        // HashTag and tweet constants
        public const int HashTagAndTweetMaxLength = 140;
        public const string HashTagAndTweetRegEx = @"([A-Za-z0-9\-\_]+)";
    }
}