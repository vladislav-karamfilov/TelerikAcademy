using System;
using System.Threading;
using System.Globalization;

class SelectionSortAlgorithm
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        // Getting the length and filling the array
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());
        double[] numbers = new double[length];
        for (int index = 0; index < length; index++)
        {
            Console.Write("Enter a real number: ");
            numbers[index] = double.Parse(Console.ReadLine().Replace(',', '.'));
        }
        // Getting the smallest element from the subarray and moving it to the first position and repeating
        for (int index1 = 0; index1 < length - 1; index1++)
        {
            int minElementIndex = index1;
            for (int index2 = index1 + 1; index2 < length; index2++)
            {
                if (numbers[index2] < numbers[minElementIndex])
                {
                    minElementIndex = index2;
                }
            }
            // A change of the indexes exist => exchange them
            if (minElementIndex != index1)
            {
                numbers[index1] = numbers[index1] + numbers[minElementIndex];
                numbers[minElementIndex] = numbers[index1] - numbers[minElementIndex];
                numbers[index1] = numbers[index1] - numbers[minElementIndex];
            }
        }
        // Printing the result
        Console.Write("The sorted array is: ");
        foreach (double number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}
