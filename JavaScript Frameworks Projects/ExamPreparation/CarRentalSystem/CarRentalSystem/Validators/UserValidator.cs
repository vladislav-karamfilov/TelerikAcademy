namespace CarRentalSystem.Validators
{
    using System;
    using System.Linq;
    using System.Text;

    public static class UserValidator
    {
        private const string ValidSessionKeyChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const string ValidUsernameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890.";
        private const string ValidDisplayNameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890 -.";

        private const int SessionKeyLength = 50;
        private const int Sha1CodeLength = 40;
        private const int MinUsernameDisplayNameChars = 6;
        private const int MaxUsernameDisplayNameChars = 30;

        private static readonly Random RandomGenerator = new Random();

        public static void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("username", "Username cannot be null!");
            }

            if (username.Length < MinUsernameDisplayNameChars)
            {
                throw new ArgumentOutOfRangeException(
                    "username",
                    string.Format("Username cannot be less than {0} characters long!", MinUsernameDisplayNameChars));
            }

            if (username.Length > MaxUsernameDisplayNameChars)
            {
                throw new ArgumentOutOfRangeException(
                    "username",
                    string.Format("Username cannot be more than {0} characters long!", MaxUsernameDisplayNameChars));
            }

            if (username.Any(ch => !ValidUsernameChars.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException("username", "Username contains invalid characters!");
            }
        }

        public static void ValidateDisplayName(string displayName)
        {
            if (displayName == null)
            {
                throw new ArgumentNullException("displayName", "Display name cannot be null!");
            }

            if (displayName.Length < MinUsernameDisplayNameChars)
            {
                throw new ArgumentOutOfRangeException(
                    "displayName",
                    string.Format("Display name cannot be less than {0} characters long!", MinUsernameDisplayNameChars));
            }

            if (displayName.Length > MaxUsernameDisplayNameChars)
            {
                throw new ArgumentOutOfRangeException(
                    "displayName",
                    string.Format("Display name cannot be more than {0} characters long!", MaxUsernameDisplayNameChars));
            }

            if (displayName.Any(ch => !ValidDisplayNameChars.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException("displayName", "Display name contains invalid characters!");
            }
        }

        public static void ValidateAuthenticationCode(string authCode)
        {
            if (authCode == null)
            {
                throw new ArgumentNullException("authCode", "Authentication code cannot be null!");
            }

            if (authCode.Length != Sha1CodeLength)
            {
                throw new ArgumentOutOfRangeException("authCode", "Invalid user authentication!");
            }
        }

        public static void ValidateSessionKey(string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException("sessionKey", "Session key cannot be null!");
            }

            if (sessionKey.Length != SessionKeyLength)
            {
                throw new ArgumentOutOfRangeException("sessionKey", "Invalid session key!");
            }

            if (sessionKey.Any(ch => !ValidSessionKeyChars.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException("sessionKey", "Session key contains invalid characters!");
            }
        }

        public static string GenerateSessionKey(int userID)
        {
            StringBuilder sessionKey = new StringBuilder(SessionKeyLength);
            sessionKey.Append(userID);
            while (sessionKey.Length < SessionKeyLength)
            {
                var index = RandomGenerator.Next(ValidSessionKeyChars.Length);
                sessionKey.Append(ValidSessionKeyChars[index]);
            }

            return sessionKey.ToString();
        }
    }
}