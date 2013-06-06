using System;

class QuickSortAlgorithm
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Implementation of the Quick Sort Algorithm for array of strings***");
        Console.Write(decorationLine);
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());
        string[] array = new string[length];
        FillArray(array, length);
        QuickSort(array, 0, length - 1);
        Console.Write("The sorted array is: ");
        PrintArray(array);
    }

    static void QuickSort(string[] array, int startIndex, int endIndex)
    {
        if (startIndex >= endIndex)
	    {
            return;
	    }
        int partitionIndex = Partition(array, startIndex, endIndex);
        QuickSort(array, startIndex, partitionIndex - 1);
        QuickSort(array, partitionIndex + 1, endIndex);
    }
    // Arranging the subarray around a pivot -> less than pivot elements, pivot element and greater than pivot elements
    static int Partition(string[] array, int startIndex, int endIndex)
    {
        string pivot = array[endIndex];
        int index1 = startIndex - 1;
        for (int index2 = startIndex; index2 < endIndex; index2++)
        {
            if (string.Compare(array[index2], pivot) < 0)
            {
                index1++;
                string temp = array[index1];
                array[index1] = array[index2];
                array[index2] = temp;
            }
        }
        string temp1 = array[index1 + 1];
        array[index1 + 1] = array[endIndex];
        array[endIndex] = temp1;
        return index1 + 1;
    }

    static void FillArray(string[] array, int length)
    {
        for (int index = 0; index < length; index++)
        {
            Console.Write("Enter array's {0} element: ", index + 1);
            array[index] = Console.ReadLine();
        }
    }

    static void PrintArray(string[] array)
    {
        foreach (string element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
