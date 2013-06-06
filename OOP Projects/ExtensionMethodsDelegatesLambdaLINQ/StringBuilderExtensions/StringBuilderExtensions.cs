using System;
using System.Text;

namespace StringBuilderExtensions
{
    public static class StringBuilderExtensions
    {
        // Gets the substring with specific length from the provided start index
        public static StringBuilder Substring(this StringBuilder wholeString, int startIndex, int length)
        {
            if (startIndex < 0 || startIndex > wholeString.Length)
            {
                throw new IndexOutOfRangeException("Start index is out of the boundaries of the string!");
            }
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot get a substring with negative length!");
            }
            int endIndex = startIndex + length;
            if (endIndex > wholeString.Length)
            {
                throw new ArgumentOutOfRangeException("The substring with the provided length gets out of the boundaries of the string!");
            }
            StringBuilder substring = new StringBuilder(length);
            for (int index = startIndex; index < endIndex; index++)
            {
                substring.Append(wholeString[index]);
            }
            return substring;
        }

        // Gets the substring from the start index to the end of the provided string
        public static StringBuilder Substring(this StringBuilder wholeString, int startIndex)
        {
            if (startIndex < 0 || startIndex > wholeString.Length)
            {
                throw new IndexOutOfRangeException("Start index is out of the boundaries of the string!");
            }
            int endIndex = wholeString.Length;
            int length = endIndex - startIndex;
            StringBuilder substring = new StringBuilder(length);
            for (int index = startIndex; index < endIndex; index++)
            {
                substring.Append(wholeString[index]);
            }
            return substring;
        }
    }
}
