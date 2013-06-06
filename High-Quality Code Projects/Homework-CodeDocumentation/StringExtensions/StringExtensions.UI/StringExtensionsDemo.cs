using System;
using Telerik.ILS.Common;

namespace StringExtensions.UI
{
    class StringExtensionsDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Demonstrating some functionality of the 'StringExtensions' class***");
            Console.Write(decorationLine);

            string testString = "this is a test string.";
            Console.WriteLine("---The test string is: '{0}'---", testString);
            Console.WriteLine();

            Console.Write("The string with capital first letter is: ");
            Console.WriteLine(testString.CapitalizeFirstLetter());
            Console.WriteLine();

            Console.Write("The cyrillic representation is: ");
            Console.WriteLine(testString.ConvertLatinToCyrillicKeyboard());
            Console.WriteLine();

            Console.Write("The MD5 hash value is: ");
            Console.WriteLine(testString.ToMd5Hash());
            Console.WriteLine();

            Console.Write("The first 5 characters are: ");
            Console.WriteLine(testString.GetFirstCharacters(5));
        }
    }
}
