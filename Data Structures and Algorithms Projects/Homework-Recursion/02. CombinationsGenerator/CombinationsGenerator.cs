using System;

class CombinationsGenerator
{
    static int[] currentCombination;
    static int k;
    static int n;

    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Generating all the combinations with duplicates of K elements from \n a N-element set***");
        Console.Write(decorationLine);

        Console.Write("Enter the number of elements N in the set: ");
        n = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of elements K in the combinations: ");
        k = int.Parse(Console.ReadLine());
        currentCombination = new int[k];

        Console.WriteLine("All combinations with duplicates C~({0}, {1}) are: ", n, k);
        GenerateCombinations(1, 0);
    }

    static void GenerateCombinations(int current, int after)
    {
        if (current > k)
        {
            return;
        }

        for (int i = after; i < n; i++)
        {
            currentCombination[current - 1] = i + 1;

            if (current == k)
            {
                PrintCurrentCombination();
            }

            GenerateCombinations(current + 1, i);
        }
    }

    private static void PrintCurrentCombination()
    {
        for (int i = 0; i < k; i++)
        {
            Console.Write("{0} ", currentCombination[i]);
        }

        Console.WriteLine();
    }
}
