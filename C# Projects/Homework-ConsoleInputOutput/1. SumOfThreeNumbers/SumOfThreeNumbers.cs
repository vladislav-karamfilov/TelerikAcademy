using System;

class SumOfThreeNumbers
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the sum of three integer numbers***");
        Console.Write(decorationLine);
        Console.Write("Enter the first integer: ");
        int firstInteger = int.Parse(Console.ReadLine());
        Console.Write("Enter the second integer: ");
        int secondInteger = int.Parse(Console.ReadLine());
        Console.Write("Enter the third integer: ");
        int thirdInteger = int.Parse(Console.ReadLine());
        long sum = firstInteger + secondInteger + thirdInteger;
        Console.WriteLine("The sum of {0}, {1} and {2} is {3}.", firstInteger, secondInteger, thirdInteger, sum);
    }
}
