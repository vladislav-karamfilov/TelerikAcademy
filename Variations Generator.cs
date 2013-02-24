using System;

class VariationsGenerator
{
    static uint n;
    static uint k;
    static uint[] variation;
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing all the variations of K elements from the set [1..N]***");
        Console.Write(decorationLine);
        Console.Write("Enter N: ");
        n = uint.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        k = uint.Parse(Console.ReadLine());
        variation = new uint[k];
        GenerateVariation(0);
    }

    static void GenerateVariation(uint currentElementIndex)
    {
        if (currentElementIndex == k)
        {
            PrintVariation();
            return;
        }
        for (uint index = 0; index < n; index++)
        {
            variation[currentElementIndex] = index + 1;
            GenerateVariation(currentElementIndex + 1);
        }
    }

    static void PrintVariation()
    {
        Console.Write("{");
        for (uint index = 0; index < variation.Length; index++)
        {
            Console.Write(variation[index] + " ");
        }
        Console.WriteLine("\b}");
    }
}
