using System;

class SubsetSums
{
    static void Main()
    {
        long s = long.Parse(Console.ReadLine()); // Enter the wanted sum
        byte n = byte.Parse(Console.ReadLine()); // Enter how many numbers the set has
        long[] numbers = new long[n];
        for (byte index = 0; index < n; index++)
        {
            numbers[index] = long.Parse(Console.ReadLine());
        }
        int numberOfSubsets = (int)Math.Pow(2, n); // The number of all subsets of n-element set
        int count = 0; // Counting the number of subsets that has sum of all elements S
        for (int subset = 1; subset < numberOfSubsets; subset++) // The subset to be examined
        {
            long currentSum = 0;
            for (int j = 0; j < n; j++) 
            {
                int mask = 1 << j; // Taking an element of the examined subset
                int jElement = subset & mask; // If it's zero the element is not in the examined subset
                if (jElement != 0)            // else adding to the sum of the other elements from the examined subset
                {
                    currentSum += numbers[j];
                }
            }
            if (currentSum == s)
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}
