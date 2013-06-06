using System;
using System.Text;

class EncodingAndDecodingAString
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Encoding and decoding a string using encryption key (cipher)***");
        Console.Write(decorationLine);
        Console.Write("Enter the text to encode: ");
        string input = Console.ReadLine();
        Console.Write("Enter the encryption key: ");
        string key = Console.ReadLine();
        int length = input.Length;
        Console.WriteLine("---Encoding the text---");
        StringBuilder encodedInput = new StringBuilder(length);
        for (int index = 0; index < length; index++)
        {
            encodedInput.Append((char)(input[index] ^ key[index % key.Length]));
        }
        Console.WriteLine("The encoded text is: " + encodedInput);
        Console.WriteLine("---Now decoding the text---");
        StringBuilder decodedInput = new StringBuilder(length);
        for (int index = 0; index < length; index++)
        {
            decodedInput.Append((char)(encodedInput[index] ^ key[index % key.Length]));
        }
        Console.WriteLine("The decoded text is: " + decodedInput);
    }
}
