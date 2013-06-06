using System;
using System.Collections.Generic;

class SumZeroOfASubsetOfFiveNumbers
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Entering five integers and then checking\nif the sum of some subset of them is 0***");
        Console.Write(decorationLine);
        int[] numbers = new int[5];
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter an integer: ");
            numbers[i] = int.Parse(Console.ReadLine());
        }
        byte numberOfSubsets = (byte)Math.Pow(2, 5);
        byte count = 0;
        for (byte i = 1; i < numberOfSubsets; i++)
        {
            List<int> subsetAnswer = new List<int>(); // The container for the subset which has sum 0
            long currentSum = 0;
            for (byte j = 0; j < 5; j++)
            {
                int mask = 1 << j;
                int jPositionBit = mask & i; // Taking the bit in position j
                if (jPositionBit != 0) // Means that the bit is 1
                {
                    currentSum += numbers[j];
                    subsetAnswer.Add(numbers[j]);
                }
            }
            if (currentSum == 0)
            {
                count++;
                if (subsetAnswer.Count != 0)
                {
                    Console.Write("A subset that has a sum 0 is (");
                    for (int k = 0; k < subsetAnswer.Count; k++)
                    {
                        if (k == subsetAnswer.Count - 1)
                        {
                            Console.Write("{0}", subsetAnswer[k]);
                        }
                        else
                        {
                            Console.Write("{0}, ", subsetAnswer[k]);
                        }
                    }
                    Console.WriteLine(").");
                }
            }
        }
        Console.WriteLine("The number of the subsets which has sum 0 is {0}.", count);
    }
}