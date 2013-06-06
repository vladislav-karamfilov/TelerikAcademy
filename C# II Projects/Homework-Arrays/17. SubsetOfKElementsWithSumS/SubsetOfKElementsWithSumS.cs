using System;
using System.Collections.Generic;

class SubsetOfKElementsWithSumS
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding a subset of K elements in an array of integers that has a sum S***");
        Console.Write(decorationLine);
        Console.Write("Enter the length of the array: ");
        // Getting the length, filling the array and getting S and K
        int length = int.Parse(Console.ReadLine());
        int[] numbers = new int[length];
        for (int index = 0; index < length; index++)
        {
            Console.Write("Enter an integer: ");
            numbers[index] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter the wanted sum S: ");
        long sum = long.Parse(Console.ReadLine());
        Console.Write("Enter the wanted number of elements K: ");
        int k = int.Parse(Console.ReadLine());
        long numberOfSubsets = (long)Math.Pow(2, length); // All the subset from the elements of the array
        bool subsetFound = false;
        // Scanning all subsets for the sum S that is formed by K elements
        for (long subset = 1; subset < numberOfSubsets; subset++)
        {
            List<int> subsetAnswer = new List<int>(); // The container for the subset which has sum S
            long currentSum = 0;
            for (int i = 0; i < length; i++)
            {
                int mask = 1 << i;
                long iPositionBit = subset & mask; // Taking the bit in position i (an element from the array)
                if (iPositionBit != 0) // Means that the bit is 1
                {
                    currentSum += numbers[i];
                    subsetAnswer.Add(numbers[i]);
                }
            }
            if (currentSum == sum && subsetAnswer.Count == k)
            {
                subsetFound = true;
                Console.Write("A subset of {0} elements that has a sum {1} is (", k, sum);
                for (int index = 0; index < subsetAnswer.Count; index++)
                {
                    if (index == subsetAnswer.Count - 1)
                    {
                        Console.Write("{0}", subsetAnswer[index]);
                    }
                    else
                    {
                        Console.Write("{0}, ", subsetAnswer[index]);
                    }
                }
                Console.WriteLine(").");
            }
        }
        if (subsetFound == false)
        {
            Console.WriteLine("There isn't a subset of {0} elements that has a sum {1}.", k, sum);
        }
    }
}
