using System;
using System.Collections.Generic;

class MergeSortAlgorithm
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Implementation of the Merge Sort Algorithm for array of integers***");
        Console.Write(decorationLine);
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());
        List<int> array = new List<int>();
        FillArray(array, length);
        List<int> sortedArray = MergeSort(array);
        PrintArray(sortedArray);
    }

    static void FillArray(List<int> array, int length)
    {
        for (int index = 0; index < length; index++)
        {
            Console.Write("Enter array's {0} element: ", index + 1);
            array.Add(int.Parse(Console.ReadLine()));
        }
    }

    static List<int> MergeSort(List<int> array)
    {
        if (array.Count <= 1) // One or less elements are always sorted
        {
            return array;
        }
        int middle = array.Count / 2;
        List<int> left = new List<int>(); // The elements to the middle of array
        for (int index = 0; index < middle; index++)
        {
            left.Add(array[index]);
        }
        List<int> right = new List<int>(); // Middle element and the rest from array
        for (int index = middle; index < array.Count; index++)
        {
            right.Add(array[index]);
        }
        left = MergeSort(left);
        right = MergeSort(right);
        return Merge(left, right);
    }
    // Merging the sorted subarrays with comparisons between the first elements
    static List<int> Merge(List<int> left, List<int> right)
    {
        List<int> result = new List<int>();
        while (left.Count > 0 || right.Count > 0)
        {
            if (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);                  
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0); 
                }
            }
            else if (right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
            else if (left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }
        }
        return result;
    }

    static void PrintArray(List<int> array)
    {
        Console.Write("The sorted array is: ");
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
