using System;

class SumOfASeries
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the sum S = 1 + 1! / X + 2! / X^2 + ... + N! / X^N\nfor two given integers X and N***");
        Console.Write(decorationLine);
        Console.Write("Enter X: ");
        int x;
        while (!int.TryParse(Console.ReadLine(), out x) || x == 0)
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter X: ");
        }
        Console.Write("Enter N: ");
        uint n;
        while (!uint.TryParse(Console.ReadLine(), out n) || n == 0)
        {
            Console.WriteLine("Invalid input! Try again...\n");
            Console.Write("Enter N: ");
        }
        decimal sum = 1M;
        decimal iFactorial = 1M;
        for (uint i = 1; i <= n; i++)
        {
            iFactorial *= i;
            sum += iFactorial / (decimal)(Math.Pow(x, i));
        }
        Console.WriteLine("The sum of the series with X = {0} and N = {1} is {2}.", x, n, sum);
    }
}
