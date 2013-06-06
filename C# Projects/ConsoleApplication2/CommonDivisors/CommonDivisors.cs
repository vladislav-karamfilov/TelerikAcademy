using System;

class CommonDivisors
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        ulong n = ulong.Parse(input[0]);
        ulong m = ulong.Parse(input[1]);
        ulong maxPrimeDivisor = Math.Min(n, m);
        bool flag = false;
        for (ulong i = 2; i <= maxPrimeDivisor; i++)
        {
            if (n % i == 0 && m % i == 0)
            {
                bool prime = true;
                for (ushort j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                if (prime)
                {
                    Console.Write(i + " ");
                    flag = true;
                }
                maxPrimeDivisor /= i;
            }
        }
        if (flag == false)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine();
        }
    }
}
