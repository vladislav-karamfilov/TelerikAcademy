using System;

class DigitName
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing the name of an entered digit***");
        Console.Write(decorationLine);
        Console.Write("Enter a digit: ");
        byte digit;
        if (!byte.TryParse(Console.ReadLine(), out digit) || (digit < 0) || (digit > 9))
        {
            Console.WriteLine("Invalid input! You have to enter a digit!");
            return;
        }
        switch (digit)
        {
            case 1: 
                Console.WriteLine("One");
                break;
            case 2: 
                Console.WriteLine("Two");
                break;
            case 3: 
                Console.WriteLine("Three");
                break;
            case 4: 
                Console.WriteLine("Four");
                break;
            case 5:
                Console.WriteLine("Five");
                break;
            case 6:
                Console.WriteLine("Six");
                break;
            case 7:
                Console.WriteLine("Seven");
                break;
            case 8:
                Console.WriteLine("Eight");
                break;
            case 9:
                Console.WriteLine("Nine");
                break;
            default:
                Console.WriteLine("Zero");
                break;
        }
    }
}