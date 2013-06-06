using System;

class ComparingFloatingPointNumbers
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Comparing floating-point numbers with precision of 0.000001***");
        Console.Write(decorationLine);
        Console.Write("Enter a floating-point number: ");
        decimal firstNumber = decimal.Parse(Console.ReadLine());
        Console.Write("Enter another floating-point number: ");
        decimal secondNumber = decimal.Parse(Console.ReadLine());
        decimal precision = 0.000001M;
        decimal absoluteDifference = Math.Abs(firstNumber - secondNumber);
        bool equalNumbers = (absoluteDifference < precision);
        Console.WriteLine("Equal numbers with precision of 0.000001? -> {0}", equalNumbers);
    }
}
