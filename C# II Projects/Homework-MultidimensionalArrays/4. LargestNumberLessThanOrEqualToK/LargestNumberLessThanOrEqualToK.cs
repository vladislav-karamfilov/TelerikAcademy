using System;

class LargestNumberLessThanOrEqualToK
{
    static int[] array;

    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Reading an array of N integers and finding the largest number \nin it which is <= of an entered number K***");
        Console.Write(decorationLine);
        Console.Write("Enter how many elements N the array has: ");
        uint length = uint.Parse(Console.ReadLine());
        array = new int[length];
        for (uint index = 0; index < length; index++)
        {
            Console.Write("Enter an integer: ");
            array[index] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter K to find the largest number which is <= K: ");
        int k = int.Parse(Console.ReadLine());
        Array.Sort(array); // Sorting the array so we can use Binary Search
        int searchIndex = Array.BinarySearch(array, k);
        if (searchIndex >= 0)
        {
            Console.WriteLine("The number {0} is found at index {1} in the sorted array.", k, searchIndex);
            return;
        }
        int answerIndex = ~searchIndex - 1;
        if (answerIndex == -1) // Every integer in the array is greater than K
        {
            Console.WriteLine("The largest number less than {0} is {1} and is at index {2} in the sorted array.", k, array[0], 1);
        }
        else
        {
            Console.WriteLine("The largest number less than {0} is {1} and is at index {2} in the sorted array.", 
                k, array[answerIndex], answerIndex + 1);
        }
    }
}
