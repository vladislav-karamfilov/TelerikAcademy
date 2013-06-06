using System;
using System.Collections.Generic;

class ShortestSequenceOfOperations
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Finding the shortest sequence of operations N = N + 1, N = N + 2, N = N * 2");
        Console.WriteLine("starting from N and finishing in M***");
        Console.Write(decorationLine);

        Console.Write("Enter start number N: ");
        int startNumber = int.Parse(Console.ReadLine());
        LinkedList<int> firstList = new LinkedList<int>();
        firstList.AddLast(startNumber);
        Queue<LinkedList<int>> solutions = new Queue<LinkedList<int>>();
        solutions.Enqueue(firstList);

        Console.Write("Enter end number M: ");
        int endNumber = int.Parse(Console.ReadLine());

        if (startNumber >= endNumber)
        {
            Console.WriteLine("Cannot have start number less than or equal to end number!");
            return;
        }

        LinkedList<int> resultList = FindMinOperations(solutions, endNumber);
        Console.Write("Result: ");
        while (resultList.Count > 0)
        {
            Console.Write("{0} ", resultList.First.Value);
            resultList.RemoveFirst();
        }

        Console.WriteLine();
    }

    static LinkedList<int> FindMinOperations(Queue<LinkedList<int>> listsQueue, int endNumber)
    {
        while (true)
        {
            LinkedList<int> currentList = listsQueue.Dequeue();
            LinkedListNode<int> currentLastElement = currentList.Last;

            int firstNextValue = currentLastElement.Value + 1;
            LinkedList<int> firstNextList = new LinkedList<int>(currentList);
            firstNextList.AddLast(firstNextValue);
            if (firstNextValue < endNumber)
            {
                listsQueue.Enqueue(firstNextList);
            }
            else if (firstNextValue == endNumber)
            {
                return firstNextList;
            }

            int secondNextValue = currentLastElement.Value + 2;
            LinkedList<int> secondNextList = new LinkedList<int>(currentList);
            secondNextList.AddLast(secondNextValue);
            if (secondNextValue < endNumber)
            {
                listsQueue.Enqueue(secondNextList);
            }
            else if (secondNextValue == endNumber)
            {
                return secondNextList;
            }

            int thirdNextValue = currentLastElement.Value * 2;
            LinkedList<int> thirdNextList = new LinkedList<int>(currentList);
            thirdNextList.AddLast(thirdNextValue);
            if (thirdNextValue < endNumber)
            {
                listsQueue.Enqueue(thirdNextList);
            }
            else if (thirdNextValue == endNumber)
            {
                return thirdNextList;
            }
        }
    }
}
