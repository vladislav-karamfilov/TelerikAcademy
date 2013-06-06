using System;

class SumOfPrimes
{
    static void Main()
    {
        ulong sum = 2;
        for (ulong i = 3; i < 2000000; i += 2)
        {
            bool prime = true;
            for (ulong j = 2; j <= Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    prime = false;
                    break;
                }
            }
            if (prime)
            {
                sum += i;
            }
        }
        Console.WriteLine(sum);
    }
}

//The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

//Find the sum of all the primes below two million.