using System;

class PermutationsGenerator
{
    static uint n;
    static uint[] permutation; // Holds the current permutation
    static bool[] usedElements; // Holds the used elements so far in the permutation
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing all the permutations of the numbers [1..N]***");
        Console.Write(decorationLine);
        Console.Write("Enter N: ");
        n = uint.Parse(Console.ReadLine());
        usedElements = new bool[n];
        permutation = new uint[n];
        GeneratePermutation(0);
    }

    static void GeneratePermutation(uint currentElementIndex)
    {
        if (currentElementIndex == n)
        {
            PrintPermutation();
            return;
        }
        for (uint index = 0; index < n; index++)
        {
            if (usedElements[index] == false)
            {
                usedElements[index] = true;
                permutation[currentElementIndex] = index + 1;
                GeneratePermutation(currentElementIndex + 1);
                usedElements[index] = false;
            }
        }
    }

    static void PrintPermutation()
    {
        Console.Write("{");
        for (uint index = 0; index < n; index++)
        {
            Console.Write(permutation[index] + " ");
        }
        Console.WriteLine("\b}");
    }
}
