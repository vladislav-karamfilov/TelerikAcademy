using System;
using System.Threading;
using System.Globalization;

class GreaterOfTwoNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the greater of two numbers***");
        Console.Write(decorationLine);
        Console.Write("Enter a number: ");
        double firstNumber = double.Parse(Console.ReadLine().Replace(',', '.'));
        Console.Write("Enter another number: ");
        double secondNumber = double.Parse(Console.ReadLine().Replace(',', '.'));
        double maxNumber = (firstNumber + secondNumber + Math.Abs(firstNumber - secondNumber)) / 2;
        Console.WriteLine("The greater of {0} and {1} is {2}.", firstNumber, secondNumber, maxNumber);
    }
}