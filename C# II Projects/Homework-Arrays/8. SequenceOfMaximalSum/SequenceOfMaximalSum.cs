using System;

class SequenceOfMaximalSum
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the sequence of maximal sum in a given array of integers***");
        Console.Write(decorationLine);
        // Getting the length and filling the array
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int index = 0; index < length; index++)
        {
            Console.Write("Enter array's {0} element: ", index + 1);
            array[index] = int.Parse(Console.ReadLine());
        }
        // Implementation of the Kadane's algorithm -> computing the max subarray ending at the scanned index
        int maxSum = int.MinValue;
        int maxSumStartIndex = 0;
        int maxSumEndIndex = 0;
        int currentMaxSum = 0;
        int currentStartIndex = 0;
        for (int currentEndIndex = 0; currentEndIndex < length; currentEndIndex++)
        {
            currentMaxSum += array[currentEndIndex];
            if (currentMaxSum > maxSum)
            {
                maxSum = currentMaxSum;
                maxSumStartIndex = currentStartIndex;
                maxSumEndIndex = currentEndIndex;
            }
            if (currentMaxSum < 0)
            {
                currentMaxSum = 0;
                currentStartIndex = currentEndIndex + 1;
            }
        }
        // Printing the result
        Console.Write("The maximum sum is {0} and its elements are: ", maxSum);
        for (int index = maxSumStartIndex; index <= maxSumEndIndex; index++)
        {
            Console.Write(array[index] + " ");
        }
        Console.WriteLine();
    }
}
