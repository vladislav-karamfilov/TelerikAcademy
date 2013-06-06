using System;
using System.Text;

class Indices
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        char[] separator = new char[] { ' ' };
        string[] inputArray = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
        for (int index = 0; index < n; index++)
        {
            array[index] = int.Parse(inputArray[index]);
        }
        bool[] visitedElements = new bool[n];
        StringBuilder result = new StringBuilder();
        int startCycleIndex = -1;
        int currentElement = 0;
        while (true)
        {
            if (currentElement < 0 || currentElement >= n)
            {
                break;
            }
            if (visitedElements[currentElement])
            {
                startCycleIndex = currentElement;
                break;
            }
            visitedElements[currentElement] = true;
            result.Append(currentElement + " ");
            currentElement = array[currentElement];
        }
        if (startCycleIndex != -1) // We are in cycle
        {
            int startIndexOfCyclingIndex = result.ToString().IndexOf(startCycleIndex + " ");
            if (startIndexOfCyclingIndex > 1)
            {
                result[startIndexOfCyclingIndex - 1] = '(';
            }
            else
            {
                result.Insert(0, '(');
            }
            result.Remove(result.Length - 1, 1);
            result.Append(")");
            Console.WriteLine(result);
            return;
        }
        result.Remove(result.Length - 1, 1);
        Console.WriteLine(result);
    }
}