using System;

class SortArrayOfStringsByLength
{
    static string[] inputArray;

    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Sorting an array of strings by the length of its elements***");
        Console.Write(decorationLine);
        Console.Write("Enter how many strings the array has: ");
        uint length = uint.Parse(Console.ReadLine());
        inputArray = new string[length];
        for (int index = 0; index < length; index++)
        {
            Console.Write("Enter a string: ");
            inputArray[index] = Console.ReadLine();
        }
        //Array.Sort(inputArray, (currentFirst, currentSecond) => currentFirst.Length.CompareTo(currentSecond.Length)); // Using lamba function
        SortByLength(length);
        Console.WriteLine("The sorted array is: ");
        foreach (string element in inputArray)
        {
            Console.WriteLine(element);
        }
    }

    // Implementation of Selection Sort Algorithm
    static void SortByLength(uint length)
    {
        for (int i = 0; i < length - 1; i++)
        {
            int minElementPosition = i;
            for (int j = i + 1; j < length; j++)
            {
                if (inputArray[j].Length < inputArray[minElementPosition].Length)
                {
                    minElementPosition = j;
                }
            }
            if (minElementPosition != i)
            {
                string temp = inputArray[i];
                inputArray[i] = inputArray[minElementPosition];
                inputArray[minElementPosition] = temp;
            }
        }
    }
}
