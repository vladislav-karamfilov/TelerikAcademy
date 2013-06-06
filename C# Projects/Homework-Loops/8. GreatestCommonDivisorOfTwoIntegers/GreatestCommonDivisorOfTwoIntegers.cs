using System;

class GreatestCommonDivisorOfTwoIntegers
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the greatest common divisor of two integer numbers***");
        Console.Write(decorationLine);
        Console.Write("Enter the first integer number: ");
        uint firstNumber;
        while (!uint.TryParse(Console.ReadLine(), out firstNumber) || firstNumber == 0)
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter the first integer number: ");
        }
        Console.Write("Enter the second integer number: ");
        uint secondNumber;
        while (!uint.TryParse(Console.ReadLine(), out secondNumber) || secondNumber == 0)
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter the second integer number: ");
        }
        do
        {
            if (firstNumber < secondNumber)
            {
                firstNumber = firstNumber + secondNumber;
                secondNumber = firstNumber - secondNumber;
                firstNumber = firstNumber - secondNumber;
            }
            firstNumber = firstNumber % secondNumber;
        }
        while (firstNumber != 0);
        Console.WriteLine("The greatest common divisor is {0}.", secondNumber);
    }
}
