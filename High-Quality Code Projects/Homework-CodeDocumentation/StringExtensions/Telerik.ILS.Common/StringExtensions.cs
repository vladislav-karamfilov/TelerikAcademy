/// <summary>
/// Telerik Integrated Learning System Common library
/// </summary>
namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides extension methods for the <see cref="System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the MD5 hash value of the current instance.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <returns>The MD5 128-bit hash value of the current instance.</returns>
        /// <seealso cref="http://en.wikipedia.org/wiki/Md5"/>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();

            // Format each byte of the hashed data as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Converts the current instance to a <see cref="System.Boolean"/> value.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <returns>The <see cref="System.Boolean"/> representation of the current instance.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the current instance to an <see cref="System.Int16"/> value.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <returns>The <see cref="System.Int16"/> representation of the current instance.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="System.Int32"/> value.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <returns>The <see cref="System.Int32"/> representation of the current instance.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the current instance to an <see cref="System.Int64"/> value.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <returns>The <see cref="System.Int64"/> representation of the current instance.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the current instance to a <see cref="System.DateTime"/> value.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <returns>The <see cref="System.DateTime"/> representation of the current instance.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes the first letter of the current instance
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <returns>
        /// A copy of this string with capital first letter or
        /// the current instance if it is null or empty
        /// </returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns the substring between <paramref name="startString"/> and <paramref name="endString"/> 
        /// starting from <paramref name="startFrom"/> index of the current instance.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <param name="startString">The string from which the result string starts.</param>
        /// <param name="endString">The string at which the result string ends.</param>
        /// <param name="startFrom">The zero-based character position from which the search starts.</param>
        /// <returns>
        /// The substring from <paramref name="startString"/> to <paramref name="endString"/>
        /// starting from <paramref name="startFrom"/> index of the current instance.
        /// </returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Replaces all cyrillic letters with their latin representations in the current instance.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <returns>A string in which all cyrillic letters are replaced by their latin representations.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Replaces all latin letters with their cyrillic representations in the current instance.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <returns>A string in which all latin letters are replaced by their cyrillic representations.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Returns a string in which all cyrillic letters in the current instance are
        /// replaced by their latin representations and all non-alphanumeric 
        /// characters (excluding ".") are removed.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <returns>
        /// A copy of the current instance in which all cyrillic letters
        /// in the current instance are replaced by their latin representations
        /// and all non-alphanumeric characters (excluding ".") are removed.
        /// </returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Returns a string in which all cyrillic letters in the current instance 
        /// are replaced by their latin representations, all white spaces are
        /// replaced by hyphens and all non-alphanumeric characters 
        /// (excluding "." and "-") are removed.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <returns>
        /// A copy of the current instance in which all cyrillic letters
        /// in the current instance are replaced by their latin representations,
        /// all white spaces are replaced by hyphens and all
        /// non-alphanumeric characters (excluding "." and "-") are removed.
        /// </returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns the first <paramref name="charsCount"/> number of characters of the current instance.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <param name="charsCount">The number of characters to be taken from the start of the current instance.</param>
        /// <returns>A string consisting from the first <paramref name="charsCount"/> characters of the current instance.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns the file extension of the current instance interpreted as a file name.
        /// </summary>
        /// <param name="fileName">The current <see cref="System.String"/> instance interpreted as a file name.</param>
        /// <returns>The file extension of the current instance.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Converts the current instance interpreted as a file extension to a content type value.
        /// </summary>
        /// <param name="fileExtension">The current <see cref="System.String"/> instance interpreted as a file extension.</param>
        /// <returns>The content type representation of the current instance.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts the current instance to a byte array value.
        /// </summary>
        /// <param name="input">The current <see cref="System.String"/> instance.</param>
        /// <returns>The byte array representation of the current instance.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
