using System;

class SequenceOfGivenSum
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding a sequence of given sum S in an array of integers***");
        Console.Write(decorationLine);
        // Getting the length and filling the array
        Console.Write("Enter the length of the array: ");
        int length = int.Parse(Console.ReadLine());
        int[] numbers = new int[length];
        for (int index = 0; index < length; index++)
        {
            Console.Write("Enter a real number: ");
            numbers[index] = int.Parse(Console.ReadLine());
        }
        // Getting S and searching elements that form it
        Console.Write("Enter the wanted sum S: ");
        long sum = long.Parse(Console.ReadLine());
        long currentSum = 0;
        int sumLength = 0;
        int sumStartIndex = 0;
        bool sequenceFound = false;
        for (int startIndex = 0; startIndex < length - 1; startIndex++)
        {
            currentSum = numbers[startIndex];
            for (int currentIndex = startIndex + 1; currentIndex < length; currentIndex++)
            {
                currentSum += numbers[currentIndex];
                if (currentSum == sum)
                {
                    sequenceFound = true;
                    sumStartIndex = startIndex;
                    sumLength = currentIndex - startIndex;
                    break;
                }
            }
        }
        if (sequenceFound)
        {
            Console.Write("A sequence that has sum {0} is: (", sum);
            for (int index = sumStartIndex; index <= sumStartIndex + sumLength; index++)
            {
                Console.Write(numbers[index] + " ");
            }
            Console.WriteLine("\b)");
        }
        else
        {
            Console.WriteLine("There is no a sequence with sum {0}.", sum);
        }
    }
}