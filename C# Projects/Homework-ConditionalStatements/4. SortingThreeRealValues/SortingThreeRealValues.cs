using System;
using System.Threading;
using System.Globalization;

class SortingThreeRealValues
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Sorting three real values in descending order***");
        Console.Write(decorationLine);
        Console.Write("Enter a real number: ");
        double firstNumber;
        if (!double.TryParse(Console.ReadLine().Replace(',', '.'), out firstNumber))
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        Console.Write("Enter a real number: ");
        double secondNumber;
        if (!double.TryParse(Console.ReadLine().Replace(',', '.'), out secondNumber))
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        Console.Write("Enter a real number: ");
        double thirdNumber;
        if (!double.TryParse(Console.ReadLine().Replace(',', '.'), out thirdNumber))
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        if ((firstNumber >= secondNumber) && (secondNumber >= thirdNumber) && (firstNumber >= thirdNumber))
        {
            Console.WriteLine("The numbers in descending order are {0} -> {1} -> {2}.", firstNumber, secondNumber, thirdNumber);
        }
        else if ((firstNumber <= secondNumber) && (secondNumber >= thirdNumber) && (firstNumber >= thirdNumber))
        {
            Console.WriteLine("The numbers in descending order are {1} -> {0} -> {2}.", firstNumber, secondNumber, thirdNumber);
        }
        else if ((firstNumber >= secondNumber) && (secondNumber <= thirdNumber) && (firstNumber >= thirdNumber))
        {
            Console.WriteLine("The numbers in descending order are {0} -> {2} -> {1}.", firstNumber, secondNumber, thirdNumber);
        }
        else if ((firstNumber <= secondNumber) && (secondNumber >= thirdNumber) && (firstNumber <= thirdNumber))
        {
            Console.WriteLine("The numbers in descending order are {1} -> {2} -> {0}.", firstNumber, secondNumber, thirdNumber);
        }
        else if ((firstNumber >= secondNumber) && (secondNumber <= thirdNumber) && (firstNumber <= thirdNumber))
        {
            Console.WriteLine("The numbers in descending order are {2} -> {0} -> {1}.", firstNumber, secondNumber, thirdNumber);
        }
        else
        {
            Console.WriteLine("The numbers in descending order are {2} -> {1} -> {0}.", firstNumber, secondNumber, thirdNumber);
        }
    }
}
