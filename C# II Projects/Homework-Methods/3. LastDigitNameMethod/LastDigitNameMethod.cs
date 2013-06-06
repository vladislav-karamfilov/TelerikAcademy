using System;

class LastDigitNameMethod
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing the name of the last digit of an entered integer***");
        Console.Write(decorationLine);
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("The name of the last digit of {0} is {1}.", number, LastDigitName(number));
    }
    static string LastDigitName(int number)
    {
        if (number < 0)
        {
            number = Math.Abs(number);
        }
        int lastDigit = number % 10;
        string result = null;
        switch (lastDigit)
        {
            case 1:
                result = "One";
                break;
            case 2:
                result = "Two";
                break;
            case 3:
                result = "Three";
                break;
            case 4:
                result = "Four";
                break;
            case 5:
                result = "Five";
                break;
            case 6:
                result = "Six";
                break;
            case 7:
                result = "Seven";
                break;
            case 8:
                result = "Eight";
                break;
            case 9:
                result = "Nine";
                break;
            default: // The digit is 0
                result = "Zero";
                break;
        }
        return result;
    }
}
