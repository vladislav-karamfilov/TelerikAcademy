using System;

class Program
{
    static uint n;
    static uint k;
    static uint[] mp = new uint[40];

    static void Print(uint length)
    {
        for (int i = 0; i < length; i++)
        {
            Console.Write(mp[i] + " ");
        }
        Console.WriteLine();
    }

    static void Combinations(uint i, uint after)
    {
        if (i > k)
        {
            return;
        }
        for (uint j = after + 1; j <= n; j++)
        {
            mp[i - 1] = j;
            if (i == k)
            {
                Print(i);
            }
            Combinations(i + 1, j);
        }
    }

    static void Main()
    {
        Console.Write("Enter n: ");
        n = uint.Parse(Console.ReadLine());
        Console.Write("Enter k: ");
        k = uint.Parse(Console.ReadLine());
        Console.WriteLine("C({0}, {1}) = ", n, k);
        Combinations(1, 0);
    }
}
