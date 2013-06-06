using System;

class BinarySearchAlgorithm
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Implementation of the Binary Search Algorithm for array of integers***");
        Console.Write(decorationLine);
        // Getting the length, filling the array and getting the searched element
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int index = 0; index < length; index++)
        {
            Console.Write("Enter the integer at {0} index: ", index);
            array[index] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter the element which index after the sort you want to be found: ");
        int element = int.Parse(Console.ReadLine());
        Array.Sort(array); // The binary search algorithm must be applied to a sorted array
        int startIndex = 0;
        int endIndex = array.Length - 1;
        int searchedIndex = -1; // So we can use it like a flag for element not found
        while (startIndex <= endIndex)
        {
            int middleIndex = (startIndex + endIndex) / 2;
            if (element < array[middleIndex])
            {
                endIndex = middleIndex - 1;
            }
            else if (element > array[middleIndex])
            {
                startIndex = middleIndex + 1;
            }
            else
            {
                searchedIndex = middleIndex;
                break;
            }
        }
        if (searchedIndex >= 0)
        {
            Console.WriteLine("The element {0} is at index {1} in the sorted array.", element, searchedIndex);
        }
        else
        {
            Console.WriteLine("There isn't such element in the array!");
        }
    }
}