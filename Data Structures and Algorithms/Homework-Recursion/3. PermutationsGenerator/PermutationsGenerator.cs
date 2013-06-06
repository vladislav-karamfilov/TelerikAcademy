using System;

class PermutationsGenerator
{
    static int[] currentPermutation;
    static int n;

    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Generating all permutations of the first N natural numbers***");
        Console.Write(decorationLine);

        Console.Write("Enter N: ");
        n = int.Parse(Console.ReadLine());
        currentPermutation = new int[n];

        InitializeCurrentPermutation();

        Console.WriteLine("All permutations P({0}) are:", n);
        // A modification of the Steinhaus–Johnson–Trotter algorithm ->
        // http://en.wikipedia.org/wiki/Steinhaus%E2%80%93Johnson%E2%80%93Trotter_algorithm
        GeneratePermutations(n);
    }

    static void InitializeCurrentPermutation()
    {
        for (int i = 0; i < n; i++)
        {
            currentPermutation[i] = i + 1;
        }
    }

    static void GeneratePermutations(int current)
    {
        if (current == 0)
        {
            PrintCurrentPermutation();
        }
        else
        {
            GeneratePermutations(current - 1);
            for (int i = 0; i < current - 1; i++)
            {
                SwapElements(i, current);
                GeneratePermutations(current - 1);
                SwapElements(i, current);
            }
        }
    }

    static void SwapElements(int i, int current)
    {
        int swap = currentPermutation[i];
        currentPermutation[i] = currentPermutation[current - 1];
        currentPermutation[current - 1] = swap;
    }

    static void PrintCurrentPermutation()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write(currentPermutation[i] + " ");
        }

        Console.WriteLine();
    }
}
