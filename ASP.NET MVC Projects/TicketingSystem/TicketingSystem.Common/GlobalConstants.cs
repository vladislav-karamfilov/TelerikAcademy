namespace TicketingSystem.Common
{
    public static class GlobalConstants
    {
        // Username constants
        public const int UsernameMinLength = 6;
        public const int UsernameMaxLength = 16;
        public const string UsernameRegEx = @"^[a-zA-Z]([/._]?[a-zA-Z0-9]+)+$";

        // Password constants
        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 500;

        // URL constants
        public const string UrlRegEx = "^(http|https)?(\\://)?(www\\.)?[a-zA-Z0-9\\-\\.]+\\.[a-zA-Z]{2,4}(/\\S*)?$";

        // Category constants
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 200;

        // Comment constants
        public const int CommentMinLength = 10;
        public const int CommentMaxLength = 1000;
        
        // Ticket constants
        public const int TicketTitleMinLength = 5;
        public const int TicketTitleMaxLength = 200;
        public const int TicketDescriptionMinLength = 10;
        public const int TicketDescriptionMaxLength = 1000;

        // Other constants
        public const string AdministratorRoleName = "Administrator";
    }
}
