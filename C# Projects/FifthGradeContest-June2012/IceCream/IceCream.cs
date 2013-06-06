using System;
// Needs to be finished...
class IceCream
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        byte n = byte.Parse(input[0]);
        long k = long.Parse(input[1]);
        byte sum = 0;
        while (k != 0)
        {
            sum += (byte)(k % 10);
            k /= 10;
        }
        if (sum < n)
        {
            Console.WriteLine(n - sum);
        }
        else
        {
            for (int i = 1; i < 10; i++)
            {
                if (sum / i == n)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(i);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
