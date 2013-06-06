using System;
using System.Diagnostics;
using System.Linq;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is null!", "Provided array to sort cannot be null!");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        for (int index = 1; index < arr.Length; index++)
        {
            Debug.Assert(arr[index - 1].CompareTo(arr[index]) <= 0, "The array is not sorted correctly!");
        }
    }
  
    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is null!", "Provided array to sort cannot be null!");
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Start index is out of the boundaries of the provided array!");
        Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "End index is out of the boundaries of the provided array!");
        Debug.Assert(endIndex > startIndex, "End index must be bigger than start index!");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Provided array to sort cannot be null!");

        for (int index = 1; index < arr.Length; index++)
        {
            Debug.Assert(arr[index - 1].CompareTo(arr[index]) <= 0, "Provided array is not sorted!");
        }

        int searchIndex = BinarySearch(arr, value, 0, arr.Length - 1);

        Debug.Assert(
            searchIndex == -1 || (searchIndex >= 0 && searchIndex < arr.Length),
            "Binary search method returned invalid index!");

        return searchIndex;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is null!", "Provided array to sort cannot be null!");
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Start index is out of the boundaries of the provided array!");
        Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "End index is out of the boundaries of the provided array!");
        Debug.Assert(endIndex > startIndex, "End index must be bigger than start index!");
        
        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].CompareTo(value) == 0)
            {
                return midIndex;
            }
            else if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array
        
        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
