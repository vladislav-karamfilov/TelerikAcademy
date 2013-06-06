using System;

class AppearancesOfANumberInAnArray
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Counting how many times a number appears in an array***");
        Console.Write(decorationLine);
        Console.Write("Enter how many elements the array has: ");
        uint length = uint.Parse(Console.ReadLine());
        double[] numbers = new double[length];
        FillArray(numbers, length);
        Console.Write("Enter the number which appearances you want to check: ");
        double number = double.Parse(Console.ReadLine());
        uint appearances = CountAppearances(numbers, number);
        Console.WriteLine("The number {0} appears {1} times in the array.", number, appearances);
    }

    static uint CountAppearances(double[] numbers, double number)
    {
        uint appearances = 0;
        foreach (double element in numbers)
        {
            if (element == number)
            {
                appearances++;
            }
        }
        return appearances;
    }

    static void FillArray(double[] numbers, uint length)
    {
        for (uint index = 0; index < length; index++)
        {
            Console.Write("Enter a number: ");
            numbers[index] = double.Parse(Console.ReadLine());
        }
    }
}
