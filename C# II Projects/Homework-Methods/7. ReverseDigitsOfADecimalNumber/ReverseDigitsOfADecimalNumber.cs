using System;
using System.Text;

class ReverseDigitsOfADecimalNumber
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Reversing the digits of a decimal number***");
        Console.Write(decorationLine);
        Console.Write("Enter a decimal number: ");
        long number = long.Parse(Console.ReadLine());
        long reversed = ReverseDigits(number);
        Console.WriteLine("The reversed number is: {0}.", reversed);
    }

    static long ReverseDigits(long number)
    {
        bool isNegative = false;
        if (number < 0)
        {
            isNegative = true;
            number = Math.Abs(number);
        }
        StringBuilder numberString = new StringBuilder(number.ToString());
        int digits = numberString.Length;
        for (int digit = 0; digit < digits / 2; digit++)
        {
            if (numberString[digit] != numberString[digits - digit - 1])
            {
                char temp = numberString[digit];
                numberString[digit] = numberString[digits - digit - 1];
                numberString[digits - digit - 1] = temp;
            }
        }
        long result = long.Parse(numberString.ToString());
        if (isNegative)
        {
            return result * (-1);
        }
        else
        {
            return result;
        }
    }
}
