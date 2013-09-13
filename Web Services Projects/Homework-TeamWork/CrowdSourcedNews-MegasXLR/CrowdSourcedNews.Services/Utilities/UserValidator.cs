namespace CrowdSourcedNews.Services.Utilities
{
    using System;
    using System.Linq;
    using System.Text;

    internal static class UserValidator
    {
        private const string SessionKeyChars = 
            "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const int SessionKeyLen = 50;
        private const int Sha1CodeLength = 40;
        private const string ValidUsernameChars = 
            "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890";
        private const string ValidNicknameChars = 
            "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890 -";
        private const int MinUsernameNicknameChars = 4;
        private const int MaxUsernameNicknameChars = 30;

        private static Random RandomGenerator = new Random();

        public static void ValidateSessionKey(string sessionKey)
        {
            if (sessionKey.Length != SessionKeyLen || sessionKey.Any(ch => !SessionKeyChars.Contains(ch)))
            {
                throw new ArgumentException("Invalid Password", "sessionKey");
            }
        }

        public static string GenerateSessionKey(int userID)
        {
            StringBuilder keyChars = new StringBuilder(50);
            keyChars.Append(userID.ToString());
            while (keyChars.Length < SessionKeyLen)
            {
                int randomCharNum;
                lock (RandomGenerator)
                {
                    randomCharNum = RandomGenerator.Next(SessionKeyChars.Length);
                }

                char randomKeyChar = SessionKeyChars[randomCharNum];
                keyChars.Append(randomKeyChar);
            }

            string sessionKey = keyChars.ToString();
            return sessionKey;
        }

        public static void ValidateUsername(string username)
        {
            if (username == null || username.Length < MinUsernameNicknameChars || username.Length > MaxUsernameNicknameChars)
            {
                throw new ArgumentException(string.Format(
                    "Username should be between {0} and {1} symbols long", 
                    MinUsernameNicknameChars, 
                    MaxUsernameNicknameChars), "username");
            }
            else if (username.Any(ch => !ValidUsernameChars.Contains(ch)))
            {
                throw new ArgumentException("Username contains invalid characters", "username");
            }
        }

        public static void ValidateNickname(string nickname)
        {
            if (nickname == null || nickname.Length < MinUsernameNicknameChars || nickname.Length > MaxUsernameNicknameChars)
            {
                throw new ArgumentException(string.Format(
                    "Nickname should be between {0} and {1} symbols long", 
                    MinUsernameNicknameChars, 
                    MaxUsernameNicknameChars), "nickname");
            }
            else if (nickname.Any(ch => !ValidNicknameChars.Contains(ch)))
            {
                throw new ArgumentException("Nickname contains invalid characters", "nickname");
            }
        }

        public static void ValidateAuthCode(string authCode)
        {
            if (authCode.Length != Sha1CodeLength)
            {
                throw new ArgumentException("Invalid user authentication", "authCode");
            }
        }
    }
}