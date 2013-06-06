using System;
using System.Threading;
using System.Globalization;

class CalculatingTheSumOfNNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the sum of N numbers***");
        Console.Write(decorationLine);
        Console.Write("Enter N: ");
        uint n = uint.Parse(Console.ReadLine());
        double sum = 0.0;
        double number = 0.0;
        for (uint i = 1; i <= n; i++)
        {
            Console.Write("Enter {0} number: ", i);
            number = double.Parse(Console.ReadLine().Replace(',', '.'));
            sum += number;
        }
        Console.WriteLine("The sum of all the numbers you have entered is {0}.", sum);
    }
}
