using System;

class SieveOfEratosthenesAlgorithm
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding all prime numbers in the range [1..10 000 000] using the Sieve of \nEratosthenes Algorithm***");
        Console.Write(decorationLine);
        const int length = 10000000;
        bool[] sieve = new bool[length]; // Using it to mark the non-prime numbers
        Console.WriteLine("All prime numbers in the range [1..10 000 000] are: ");
        for (int divisor = 2; divisor < length; divisor++)
        {
            if (sieve[divisor] == false)
            {
                Console.Write(divisor + " ");
                int multiple = divisor;
                // Marking all the element that are multiples to divisor like non-prime
                while (multiple < length)
                {
                    sieve[multiple] = true;
                    multiple += divisor;
                }
            }
        }
        Console.WriteLine();
    }
}
