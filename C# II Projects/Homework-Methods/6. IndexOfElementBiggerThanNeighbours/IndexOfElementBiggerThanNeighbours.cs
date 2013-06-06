using System;

class IndexOfElementBiggerThanNeighbours
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the position of the first element in an array of numbers \nwhich is bigger than its neighbours***");
        Console.Write(decorationLine);
        Console.Write("Enter how many elements the array has: ");
        uint length = uint.Parse(Console.ReadLine());
        double[] numbers = new double[length];
        FillArray(numbers, length);
        int index = CompareNeighbours(numbers, length);
        if (index == -1)
        {
            Console.WriteLine("There is no element which is bigger than its neighbours.");
        }
        else
        {
            Console.WriteLine("The element {0} on position {1} is the first that is bigger than its neighbours.", numbers[index], index + 1);
        }
    }

    static void FillArray(double[] numbers, uint length)
    {
        for (uint index = 0; index < length; index++)
        {
            Console.Write("Enter the number at position {0}: ", index + 1);
            numbers[index] = double.Parse(Console.ReadLine());
        }
    }

    static int CompareNeighbours(double[] numbers, uint length)
    {
        if (length == 1 || numbers[0] > numbers[1]) // The array is from one element or the first element is bigger than the second one
        {
            return 0;
        }
        for (int index = 1; index < length - 1; index++)
        {
            if (numbers[index] > numbers[index - 1] && numbers[index] > numbers[index + 1])
            {
                return index;
            }
        }
        if (numbers[length - 1] > numbers[length - 2]) // The last element is bigger than the previous one
        {
            return (int)(length - 1);
        }
        return -1;
    }
}