using System;
using System.Text;

namespace StringBuilderExtensions
{
    class SubstringDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Getting a specific length substring from a specific index in a StringBuilder object***");
            Console.Write(decorationLine);

            Console.Write("Enter the string from which to get the substring: ");
            StringBuilder wholeString = new StringBuilder(Console.ReadLine());
            Console.Write("Enter the start index from which to get the substring: ");
            int startIndex = int.Parse(Console.ReadLine());
            Console.Write("Enter the length of the substring: ");
            int length = int.Parse(Console.ReadLine());

            StringBuilder substring = wholeString.Substring(startIndex, length);
            Console.WriteLine("The substring from index {0} with length {1} is: {2}", startIndex, length, substring);

            StringBuilder substringToEnd = wholeString.Substring(startIndex);
            Console.WriteLine("The substring from index {0} to the end of the string is: {1}", startIndex, substringToEnd);
        }
    }
}
