using System;

class SumOfMultiplesOf3And5
{
    static void Main()
    {
        uint sum = 0;
        for (ushort i = 3; i < 1000; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }
        Console.WriteLine(sum);
    }
}
// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

// Find the sum of all the multiples of 3 or 5 below 1000.