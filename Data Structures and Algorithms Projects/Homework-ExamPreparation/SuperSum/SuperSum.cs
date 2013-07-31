using System;

class SuperSum
{
    static void Main()
    {
        string[] kAndN = Console.ReadLine().Split(' ');
        int k = int.Parse(kAndN[0]);
        int n = int.Parse(kAndN[1]);

        Console.WriteLine(GetSuperSum(k, n));
    }

    static int GetSuperSum(int k, int n)
    {
        int[,] superSums = new int[k + 1, n + 1];
        for (int i = 0; i < superSums.GetLength(1); i++)
        {
            superSums[0, i] = i;
        }

        for (int i = 1; i <= k; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                for (int p = 0; p <= j; p++)
                {
                    superSums[i, j] += superSums[i - 1, p];
                }
            }
        }

        return superSums[k, n];
    }
}
