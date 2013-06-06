using System;

class ZeroesAtTheEndOfNFactorial
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating how many trailing zeroes present at the end of N!***");
        Console.Write(decorationLine);
        Console.Write("Enter N: ");
        uint n;
        while (!uint.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("Ivalid input! Try again...\n");
            Console.Write("Enter N: ");
        }
        uint top = (uint)Math.Log(n, 5);
        uint zeroesCounter = 0U;
        //The number of trailing zeroes of N! is equal to the sum of (N/5^i) where i belongs to [1, log(5)N]
        for (uint i = 1U; i <= top; i++)
        {
            zeroesCounter += (uint)(n / Math.Pow(5, i));
        }
        Console.WriteLine("The trailing zeroes at the end of {0}! are {1}.", n, zeroesCounter);
    }
}
