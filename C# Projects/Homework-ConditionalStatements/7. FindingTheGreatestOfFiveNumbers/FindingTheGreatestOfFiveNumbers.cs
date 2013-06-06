using System;
using System.Threading;
using System.Globalization;

class FindingTheGreatestOfFiveNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the greatest of five numbers***");
        Console.Write(decorationLine);
        double number = 0;
        double maxNumber = double.MinValue;
        for (int counter = 0; counter < 5; counter++)
        {
            Console.Write("Enter a number: ");
            if (!double.TryParse(Console.ReadLine().Replace(',', '.'), out number))
            {
                Console.WriteLine("Invalid input!");
                return;
            }
            if (number > maxNumber)
            {
                maxNumber = number;
            }
        }
        Console.WriteLine("The greatest number is {0}.", maxNumber);
    }
}
