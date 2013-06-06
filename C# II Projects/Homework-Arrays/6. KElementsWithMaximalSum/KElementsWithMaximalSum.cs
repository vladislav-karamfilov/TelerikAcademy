using System;

class KElementsWithMaximalSum
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding those K elements in an array of N integers that have maximal sum***");
        Console.Write(decorationLine);
        // Getting the length, filling the array and getting K
        Console.Write("Enter the size N of the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int index = 0; index < n; index++)
        {
            Console.Write("Enter an integer: ");
            numbers[index] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter the number of elements K that will have the maximal sum: ");
        int k = int.Parse(Console.ReadLine());
        // Sorting the array => the last K elements have maximal sum
        Array.Sort(numbers);
        int maxSum = 0;
        Console.Write("The {0} elements that have maximal sum are: ", k);
        for (int index = numbers.Length - k; index < numbers.Length; index++)
        {
            Console.Write(numbers[index] + " ");
            maxSum += numbers[index];
        }
        Console.WriteLine("\nThe maximal sum is: {0}.", maxSum);
    }
}
