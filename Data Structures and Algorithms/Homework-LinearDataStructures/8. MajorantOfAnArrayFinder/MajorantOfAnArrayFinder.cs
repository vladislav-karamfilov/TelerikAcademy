using System;
using System.Collections.Generic;

class MajorantOfAnArrayFinder
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the majorant of an array***");
        Console.Write(decorationLine);

        Console.Write("Enter how many numbers the array has: ");
        int arrayLength = int.Parse(Console.ReadLine());
        double[] inputArray = new double[arrayLength];
        for (int index = 0; index < arrayLength; index++)
        {
            Console.Write("Enter a number: ");
            inputArray[index] = double.Parse(Console.ReadLine());
        }

        Stack<double> stack = new Stack<double>();
        for (int index = 0; index < arrayLength; index++)
        {
            if (stack.Count == 0)
            {
                stack.Push(inputArray[index]);
            }
            else
            {
                if (inputArray[index] == stack.Peek())
                {
                    stack.Push(inputArray[index]);
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        if (stack.Count == 0)
        {
            Console.WriteLine("The array has not a majorant!");
            return;
        }

        double majorantCandidate = stack.Pop();
        int majorantCandidateOccurrences = 0;
        for (int index = 0; index < arrayLength; index++)
        {
            if (majorantCandidate == inputArray[index])
            {
                majorantCandidateOccurrences++;
            }
        }

        if (majorantCandidateOccurrences >= arrayLength / 2 + 1)
        {
            Console.WriteLine("The majorant of the array is {0} with {1} occurrences!", majorantCandidate, majorantCandidateOccurrences);
        }
        else
        {
            Console.WriteLine("The array has not a majorant!");
        }
    }
}
