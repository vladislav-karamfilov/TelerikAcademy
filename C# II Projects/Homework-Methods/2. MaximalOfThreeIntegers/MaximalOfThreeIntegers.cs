using System;

class MaximalOfThreeIntegers
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the maximal of three integers***");
        Console.Write(decorationLine);
        Console.Write("Enter the first integer: ");
        int first = int.Parse(Console.ReadLine());
        Console.Write("Enter the second integer: ");
        int second = int.Parse(Console.ReadLine());
        Console.Write("Enter the third integer: ");
        int third = int.Parse(Console.ReadLine());
        int tempMax = GetMax(first, second);
        int max = GetMax(tempMax, third);
        Console.WriteLine("The maximal of {0}, {1} and {2} is {3}.", first, second, third, max);
    }
    static int GetMax(int first, int second)
    {
        if (first > second)
        {
            return first;
        }
        else // second >= first
        {
            return second;
        }
    }
}
