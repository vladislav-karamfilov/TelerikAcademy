using System;

class AllSubsetsOfKStrings
{
    static string[] stringsSet;
    static int[] currentSubsetIndices;
    static int n;
    static int k;

    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Generating all subsets of K strings from a set of strings***");
        Console.Write(decorationLine);

        Console.Write("Enter how many elements the set of strings has: ");
        n = int.Parse(Console.ReadLine());
        stringsSet = GetInputStrings(n);

        Console.Write("Enter how many elements K the subsets have: ");
        k = int.Parse(Console.ReadLine());
        currentSubsetIndices = new int[k];

        // To find all subsets of K elements -> generate all 
        // combinations without duplicates of K elements from N-element set
        GetAllSubsets(1, 0);
    }

    private static void GetAllSubsets(int current, int after)
    {
        if (current > k)
        {
            return;
        }
        else
        {
            for (int i = after + 1; i <= n; i++)
            {
                currentSubsetIndices[current - 1] = i - 1;

                if (current == k)
                {
                    PrintCurrentStringsSubset();
                }

                GetAllSubsets(current + 1, i);
            }
        }
    }

    private static void PrintCurrentStringsSubset()
    {
        for (int i = 0; i < k; i++)
        {
            int currentStringIndex = currentSubsetIndices[i];
            Console.Write("{0} ", stringsSet[currentStringIndex]);
        }
        Console.WriteLine();
    }

    private static string[] GetInputStrings(int count)
    {
        string[] inputStrings = new string[count];
        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter string #{0}: ", i + 1);
            inputStrings[i] = Console.ReadLine();
        }

        return inputStrings;
    }
}
