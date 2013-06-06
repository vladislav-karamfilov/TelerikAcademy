using System;
using System.Collections.Generic;

class MaximalIncreasingSequence
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Removing a minimal number of elements from an array of integers in such \nway that the remaining array is sorted in increasing order***");
        Console.Write(decorationLine);
        // Getting the length and filling the array
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());
        int[] numbers = new int[length];
        for (int index = 0; index < length; index++)
        {
            Console.Write("Enter an integer: ");
            numbers[index] = int.Parse(Console.ReadLine());
        }
        // We will find the list with the most elements in increasing order
        long numberOfSubsets = (long)Math.Pow(2, length);
        int bestLength = 0;
        List<int> longestSequence = new List<int>();
        for (long subset = 1; subset < numberOfSubsets; subset++)
        {
            List<int> currentSequence = new List<int>();
            for (int i = 0; i < length; i++)
            {
                int mask = 1 << i;
                long iPositionBit = subset & mask; // Taking the bit in position i (an element from array)
                if (iPositionBit != 0) // Means that the bit is 1
                {
                    // Comparing the element with the last element in the list
                    if (currentSequence.Count != 0 && numbers[i] >= currentSequence[currentSequence.Count - 1])
                    {
                        currentSequence.Add(numbers[i]);
                    }
                    else if (currentSequence.Count == 0)
                    {
                        currentSequence.Add(numbers[i]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (bestLength < currentSequence.Count)
            {
                bestLength = currentSequence.Count;
                longestSequence.Clear();
                foreach (int element in currentSequence)
                {
                    longestSequence.Add(element);
                }
            }
        }
        Console.Write("The longest sorted array that remains is: {");
        foreach (int element in longestSequence)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine("\b}");
    }
}