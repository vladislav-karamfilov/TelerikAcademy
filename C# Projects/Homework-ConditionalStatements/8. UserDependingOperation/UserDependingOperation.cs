using System;
using System.Text;

class UserDependingOperation
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Performing an operation depending on your variable choice***");
        Console.Write(decorationLine);
        Console.Write("To choose a variable enter \"I\" for integer, \n\"D\" for double and \"S\" for string: ");
        char choice = Convert.ToChar(Console.ReadLine());
        switch (choice)
        {
            case 'i':
            case 'I':
                Console.Write("Enter an integer: ");
                int varInt = int.Parse(Console.ReadLine());
                Console.WriteLine("After increasing your value with 1, the new value is {0}.", varInt + 1);
                break;
            case 'd':
            case 'D':
                Console.Write("Enter a real number: ");
                double varDouble = double.Parse(Console.ReadLine());
                Console.WriteLine("After increasing your value with 1, the new value is {0}.", varDouble + 1);
                break;
            case 's':
            case 'S':
                Console.Write("Enter a string: ");
                string varString = Console.ReadLine();
                StringBuilder newString = new StringBuilder(varString).Append('*');
                Console.WriteLine("After appending your string with \'*\', the new string is \"{0}\".", newString);
                break;
            default:
                Console.WriteLine("Invalid input!");
                break;
        }
    }
}