using System;

class CombinationsGenerator
{
    static uint n;
    static uint k;
    static uint[] combination;
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing all the combinations of K distinct elements from the set [1..N]***");
        Console.Write(decorationLine);
        Console.Write("Enter N: ");
        n = uint.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        k = uint.Parse(Console.ReadLine());
        combination = new uint[k];
        GenerateCombination(1, 0);
    }

    static void GenerateCombination(uint currentElementIndex, uint afterElement)
    {
        if (currentElementIndex > k)
        {
            return;
        }
        for (uint index = afterElement + 1; index <= n; index++)
        {
            combination[currentElementIndex - 1] = index;
            if (currentElementIndex == k)
            {
                PrintCombination();
            }
            GenerateCombination(currentElementIndex + 1, index);
        }
    }

    static void PrintCombination()
    {
        Console.Write("{");
        for (uint index = 0; index < combination.Length; index++)
        {
            Console.Write(combination[index] + " ");
        }
        Console.WriteLine("\b}");
    }
}
