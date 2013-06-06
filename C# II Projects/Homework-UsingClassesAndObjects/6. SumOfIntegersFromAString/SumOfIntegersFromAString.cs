using System;

class SumOfIntegersFromAString
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the sum of positive integers written in a string, \nseparated by spaces***");
        Console.Write(decorationLine);
        Console.Write("Enter positive integers separated by spaces: ");
        uint[] integers = InputIntegers();
        ulong sum = CalculateSum(integers);
        Console.WriteLine("The sum of the entered positive integers is {0}.", sum);
    }

    static ulong CalculateSum(uint[] integers)
    {
        ulong sum = 0;
        foreach (uint integer in integers)
        {
            sum += integer;
        }
        return sum;
    }

    static uint[] InputIntegers()
    {
        string[] input = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        uint[] integers = new uint[input.Length];
        for (int index = 0; index < input.Length; index++)
        {
            integers[index] = uint.Parse(input[index]);
        }
        return integers;
    }
}