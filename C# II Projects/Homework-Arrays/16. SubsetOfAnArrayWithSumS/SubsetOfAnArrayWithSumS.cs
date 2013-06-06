using System;
using System.Collections.Generic;

class SubsetOfAnArrayWithSumS
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding if there is a subset of the elements of an array of integers \nthat has a sum S***");
        Console.Write(decorationLine);
        // Getting the length, filling the array and getting S
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());
        int[] numbers = new int[length];
        for (int index = 0; index < length; index++)
        {
            Console.Write("Enter an integer: ");
            numbers[index] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter the wanted sum S: ");
        long sum = long.Parse(Console.ReadLine());
        long numberOfSubsets = (long)Math.Pow(2, length);
        bool subsetFound = false;
        for (long subset = 1; subset < numberOfSubsets; subset++)
        {
            List<int> subsetAnswer = new List<int>(); // The container for the subset which has sum S
            long currentSum = 0;
            for (int i = 0; i < length; i++)
            {
                int mask = 1 << i;
                long iPositionBit = subset & mask; // Taking the bit in position i (the bit represents an element)
                if (iPositionBit != 0) // Means that the bit is 1
                {
                    currentSum += numbers[i];
                    subsetAnswer.Add(numbers[i]);
                }
            }
            if (currentSum == sum)
            {
                subsetFound = true;
                if (subsetAnswer.Count != 0)
                {
                    Console.Write("A subset that has a sum {0} is (", sum);
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
        }
        if (subsetFound == false)
        {
            Console.WriteLine("There isn't a subset that has a sum {0}.", sum);
        }
    }
}
