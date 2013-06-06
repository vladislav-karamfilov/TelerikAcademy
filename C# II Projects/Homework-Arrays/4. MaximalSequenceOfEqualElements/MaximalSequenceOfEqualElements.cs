using System;

class MaximalSequenceOfEqualElements
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the maximal sequence of equal elements in an array of integers***");
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
        int currentElement = array[0];
        int bestLength = 1;
        int currentLength = 1;
        int startIndex = 0; // The index from which the maximal sequence begins
        for (int index = 1; index < length; index++)
        {
            if (array[index] == currentElement)
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
                currentElement = array[index];
                currentLength = 1;
            }
        }
        Console.Write("The maximal sequence of equal elements consist of {0} elements: ", bestLength);
        for (int index = startIndex; index < startIndex + bestLength; index++)
        {
            Console.Write(array[index] + " ");
        }
        Console.WriteLine();
    }
}
