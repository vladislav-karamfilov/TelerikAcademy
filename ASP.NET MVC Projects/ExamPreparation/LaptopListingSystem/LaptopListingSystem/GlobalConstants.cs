namespace LaptopListingSystem
{
    public class GlobalConstants
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

        // URL constants
        public const string UrlRegEx = "^(http|https)?(\\://)?(www\\.)?[a-zA-Z0-9\\-\\.]+\\.[a-zA-Z]{2,4}(/\\S*)?$";
    }
}