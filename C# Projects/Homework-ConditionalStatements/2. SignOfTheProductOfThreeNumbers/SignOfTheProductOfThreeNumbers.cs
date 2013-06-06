using System;
using System.Threading;
using System.Globalization;

class SignOfTheProductOfThreeNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing information about the sign of the product of three numbers***");
        Console.Write(decorationLine);
        Console.Write("Enter first real number: ");
        double firstNumber;
        if (!double.TryParse(Console.ReadLine().Replace(',', '.'), out firstNumber))
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        Console.Write("Enter second real number: ");
        double secondNumber;
        if (!double.TryParse(Console.ReadLine().Replace(',', '.'), out secondNumber))
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        Console.Write("Enter third real number: ");
        double thirdNumber;
        if (!double.TryParse(Console.ReadLine().Replace(',', '.'), out thirdNumber))
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        if ((firstNumber == 0d) || (secondNumber == 0d) || (thirdNumber == 0d))
        {
            Console.WriteLine("The product is 0.");
            return;
        }
        bool sign = true; // Means positive
        if (firstNumber < 0d)
        {
            sign = !sign; 
        }
        if (secondNumber < 0d)
        {
            sign = !sign;
        }
        if (thirdNumber < 0d)
        {
            sign = !sign;
        }
        if (sign == true)
        {
            Console.WriteLine("The product of {0}, {1} and {2} is positive.", firstNumber, secondNumber, thirdNumber);
        }
        else
        {
            Console.WriteLine("The product of {0}, {1} and {2} is negative.", firstNumber, secondNumber, thirdNumber);
        }
    }
}

