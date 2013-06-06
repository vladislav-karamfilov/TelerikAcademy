using System;
// Doesn't work...

class SuperSumSolver
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        byte k = byte.Parse(input[0]);
        byte n = byte.Parse(input[1]);
        uint answer = SuperSum(k, n);
        Console.WriteLine(answer);
    }
    static uint SuperSum(byte k, byte n)
    {
        uint sum = n;
        if (k == 1)
        {
            for (uint i = 1; i < n; i++)
            {
                sum += i;
            }
            return sum;
        }
        if (n > 0)
        {
            n--;
            return SuperSum(k, n);
        }
        return SuperSum((byte)(k - 1), n);
    }
}

