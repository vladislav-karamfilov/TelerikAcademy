using System;

class ComparisonWithNeighbours
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Checking if the element at some position in an array of integers is bigger \nthan its neighbours***");
        Console.Write(decorationLine);
        Console.Write("Enter how many elements the array has: ");
        uint length = uint.Parse(Console.ReadLine());
        int[] numbers = new int[length];
        FillArray(numbers, length);
        Console.Write("Enter the position of the element you want to check: ");
        uint position = uint.Parse(Console.ReadLine());
        bool comparison = CompareWithNeighbours(numbers, length, position - 1);
        if (comparison)
        {
            Console.WriteLine("The element in position {0} is bigger than its neighbours.", position);
        }
        else
        {
            Console.WriteLine("The element in position {0} is not bigger than its neighbours.", position);
        }
    }

    static void FillArray(int[] numbers, uint length)
    {
        for (uint index = 0; index < length; index++)
        {
            Console.Write("Enter the number at position {0}: ", index + 1);
            numbers[index] = int.Parse(Console.ReadLine());
        }
    }

    static bool CompareWithNeighbours(int[] numbers, uint length, uint position)
    {
        if (position == 0) // The first element to be compared to the second one
        {
            if (length == 1) // Special case: the array is with one element
            {
                return true;
            }
            if (numbers[position] > numbers[position + 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (position == length - 1) // The last element to be compared to the previous one
        {
            if (numbers[position] > numbers[position - 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (numbers[position] > numbers[position - 1] && numbers[position] > numbers[position + 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
