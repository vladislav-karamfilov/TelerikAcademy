using System;

class MaximalIncreasingSequence
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the maximal increasing sequence in an array of integers***");
        Console.Write(decorationLine);
        // Getting the length and filling the array
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int index = 0; index < length; index++)
        {
            Console.Write("Enter an integer: ");
            array[index] = int.Parse(Console.ReadLine());
        }
        // Scanning through the array and printing the result
        int bestLength = 1;
        int currentLength = 1;
        int startIndex = 0; // The index from which the maximal sequence begins
        for (int index = 1; index < length; index++)
        {
            if (array[index] > array[index - 1])
            {
                currentLength++;
                if (currentLength > bestLength)
                {
                    bestLength = currentLength;
                    startIndex = index - bestLength + 1;
                }
            }
            else
            {
                currentLength = 1;
            }
        }
        Console.Write("The maximal increasing sequence in the array consist of {0} elements: ", bestLength);
        for (int index = startIndex; index < startIndex + bestLength; index++)
        {
            Console.Write(array[index] + " ");
        }
        Console.WriteLine();
    }
}
