using System;

class SumOfSubsequences
{
    static void Main()
    {
        int testsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < testsCount; i++)
        {
            string[] nAndK = Console.ReadLine().Split(' ');
            int n = int.Parse(nAndK[0]);
            int k = int.Parse(nAndK[1]);

            int[] sequence = new int[n];
            string[] numbersStringsInSequence =
                Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int sumOfSubsequences = 0;
            for (int j = 0; j < n; j++)
            {
                sequence[j] = int.Parse(numbersStringsInSequence[j]);
                sumOfSubsequences += sequence[j];
            }

            Console.WriteLine(sumOfSubsequences * GetBinomialCoefficient(n - 1, k));
        }
    }

    static long GetBinomialCoefficient(int n, int k)
    {
        long nominator = 1;
        for (int i = n; i >= (n - k + 1); i--)
        {
            nominator *= i;
        }

        long denominator = 1;
        for (int i = k; i >= 1; i--)
        {
            denominator *= i;
        }

        return nominator / denominator;
    }
}
