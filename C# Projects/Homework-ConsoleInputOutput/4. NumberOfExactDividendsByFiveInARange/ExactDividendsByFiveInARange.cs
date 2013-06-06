using System;

class ExactDividendsByFiveInARange
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding how many numbers exist, between two positive\nintegers, such that the remainder of the division by 5 is 0***");
        Console.Write(decorationLine);
        Console.Write("Enter a positive integer: ");
        uint firstNumber = uint.Parse(Console.ReadLine());
        Console.Write("Enter another positive integer: ");
        uint secondNumber = uint.Parse(Console.ReadLine());
        if (firstNumber > secondNumber)
        {
            firstNumber = firstNumber + secondNumber;
            secondNumber = firstNumber - secondNumber;
            firstNumber = firstNumber - secondNumber;
        }
        int countDividends = 0;
        for (uint i = firstNumber; i <= secondNumber; i++)
        {
            if (i % 5 == 0)
            {
                countDividends++;
            }
        }
        Console.WriteLine("The number of the exact dividends by 5 which are between {0} and {1} is {2}.", firstNumber, secondNumber, countDividends);
    }
}
