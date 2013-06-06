using System;

class MaximalElementInSubarrayAndSorts
{
    static uint length;
    static uint maxElementIndex;
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Sorting an array of integers in ascending and descending order***");
        Console.Write(decorationLine);
        Console.Write("Enter how many elements the array has: ");
        length = uint.Parse(Console.ReadLine());
        int[] numbers = new int[length];
        FillArray(numbers);
        DescendingSort(numbers);
        Console.WriteLine("The sorted in descending order array is: ");
        PrintArray(numbers);
        int[] sort = AscendingSort(numbers);
        Console.WriteLine("The array after the ascending sort is: ");
        PrintArray(sort);
    }
    
    static int[] AscendingSort(int[] numbers)
    {
        int[] result = new int[length];
        for (uint index = 0; index < length; index++)
        {
            result[length - index - 1] = MaxElementInPortion(numbers, index);
            numbers[maxElementIndex] = numbers[index];
        }
        return result;
    }

    static void DescendingSort(int[] numbers)
    {
        for (uint index = 0; index < length; index++)
        {
            int temp = numbers[index];
            numbers[index] = MaxElementInPortion(numbers, index);
            numbers[maxElementIndex] = temp;
        }
    }

    // Finding the maximal element in an array from startIndex to the end
    static int MaxElementInPortion(int[] numbers, uint startIndex)
    {
        int maxElement = numbers[startIndex];
        maxElementIndex = startIndex;
        for (uint index = startIndex + 1; index < length; index++)
        {
            if (numbers[index] > maxElement)
            {
                maxElement = numbers[index];
                maxElementIndex = index;
            }
        }
        return maxElement;
    }

    static void FillArray(int[] numbers)
    {
        for (uint index = 0; index < length; index++)
        {
            Console.Write("Enter a number: ");
            numbers[index] = int.Parse(Console.ReadLine());
        }
    }

    static void PrintArray(int[] numbers)
    {
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}
