using System;
using System.Text;

class ReversingAString
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Reading a string, reversing it and printing it at the console***");
        Console.Write(decorationLine);
        Console.Write("Enter a string: ");
        string inputString = Console.ReadLine();
        int length = inputString.Length;
        StringBuilder reversedString = new StringBuilder(inputString);
        for (int index = 0; index < length / 2; index++)
        {
            if (inputString[index] != inputString[length - index - 1]) // Exchanging symbols only if they are different
            {
                char temp = reversedString[index];
                reversedString[index] = reversedString[length - index - 1];
                reversedString[length - index - 1] = temp;
            }
        }
        Console.WriteLine("The reversed string is \"{0}\".", reversedString);
    }
}
