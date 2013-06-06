using System;

class TwentyCharactersString
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Reading a string of maximum 20 characters and filling it with '*' \nif the input is less than 20 characters***");
        Console.Write(decorationLine);
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        if (input.Length > 20)
        {
            Console.WriteLine("The new string is: " + input.Remove(20));
        }
        else if (input.Length < 20)
        {
            Console.WriteLine("The new string is: " + input.PadRight(20, '*'));
        }
        else // The length is 20
        {
            Console.WriteLine("The string is the same: " + input);
        }
    }
}
