using System;

class PermutationsWithRepetitions
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Generating all permutations with repetitions of a multi-set***");
        Console.Write(decorationLine);

        int[] multiSet = { 51, -22, 6, 5, 5, -4, 5, 6 };
        Array.Sort(multiSet);
        GeneratePermutationsWithRepetitions(multiSet, 0);
    }

    static void GeneratePermutationsWithRepetitions<T>(T[] multiSet, int startIndex)
    {
        PrintMultiSet(multiSet);

        for (int left = multiSet.Length - 2; left >= startIndex; left--)
        {
            for (int right = left + 1; right < multiSet.Length; right++)
            {
                if (!multiSet[left].Equals(multiSet[right]))
                {
                    Swap(ref multiSet[left], ref multiSet[right]);
                    GeneratePermutationsWithRepetitions(multiSet, left + 1);
                }
            }

            T firstElement = multiSet[left];
            for (int i = left; i < multiSet.Length - 1; i++)
            {
                multiSet[i] = multiSet[i + 1];
            }

            multiSet[multiSet.Length - 1] = firstElement;
        }
    }

    static void PrintMultiSet<T>(T[] multiSet)
    {
        Console.WriteLine("[{0}]", string.Join(", ", multiSet));
    }

    static void Swap<T>(ref T first, ref T second)
    {
        T swapValue = first;
        first = second;
        second = swapValue;
    }
}
