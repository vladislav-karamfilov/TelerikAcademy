using System;

class PrimeNumberCheck
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Checking if a positive integer <= 100 is prime***");
        Console.Write(decorationLine);
        Console.Write("Enter a positive integer <= 100: ");
        byte testNumber = byte.Parse(Console.ReadLine());
        bool isPrime = true;
        for (int divisor = 2; divisor <= Math.Sqrt(testNumber); divisor++)
        {
            if ((testNumber % divisor) == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime == true)
        {
            Console.WriteLine("The number {0} is prime.", testNumber);
        }
        else
        {
            Console.WriteLine("The number {0} is not prime.", testNumber);
        }
    }
}