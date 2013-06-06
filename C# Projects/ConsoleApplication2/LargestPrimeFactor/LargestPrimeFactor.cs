using System;
using System.Diagnostics;

class LargestPrimeFactor
{
    static void Main()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();
        long number = 600851475143;
        for (long i = 2; i <= number; i++)
        {
            if (number % i == 0)
            {
                Console.WriteLine(i);
                number /= i;
                while (number % i == 0)
                {
                    number /= i;
                }
            }
        }
        Console.WriteLine(watch.Elapsed);
    }
}

//The prime factors of 13195 are 5, 7, 13 and 29.

//What is the largest prime factor of the number 600851475143?