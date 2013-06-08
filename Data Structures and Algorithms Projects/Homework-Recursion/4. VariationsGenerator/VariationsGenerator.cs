using System;

class VariationsGenerator
{
    static int[] currentVariation;
    static int n;
    static int k;

    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Generating all variations of K elements from a N-element set***");
        Console.Write(decorationLine);

        Console.Write("Enter the number of the elements N in the set: ");
        n = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of the elements K in the variations: ");
        k = int.Parse(Console.ReadLine());
        currentVariation = new int[k];

        Console.WriteLine("All variations V({0}, {1}) are:", n, k);
        GenerateVariations(0);
    }

    private static void GenerateVariations(int current)
    {
        if (current == k)
        {
            PrintCurrentVariation();
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                currentVariation[current] = i + 1;
                GenerateVariations(current + 1);
            }
        }
    }

    private static void PrintCurrentVariation()
    {
        for (int i = 0; i < k; i++)
        {
            Console.Write(currentVariation[i] + " ");
        }

        Console.WriteLine();
    }
}
