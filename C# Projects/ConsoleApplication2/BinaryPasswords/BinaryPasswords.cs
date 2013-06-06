using System;

class BinaryPasswords
{
    static void Main()
    {
        string password = Console.ReadLine();
        ulong combinations = 1;
        foreach (char symbol in password)
        {
            if (symbol == '*')
            {
                combinations *= 2;
            }
        }
        Console.WriteLine(combinations);
    }
}
