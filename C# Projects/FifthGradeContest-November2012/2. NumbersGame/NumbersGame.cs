using System;

class NumbersGame
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine()); // Enter four-digit number
        int temp = number;
        int digit4 = temp % 10;
        temp /= 10;
        int digit3 = temp % 10;
        temp /= 10;
        int digit2 = temp % 10;
        temp /= 10;
        int digit1 = temp % 10;
        int newNumber = digit2 * 1000 + digit1 * 100 + digit4 * 10 + digit3;
        Console.WriteLine(newNumber + number);
    }
}
