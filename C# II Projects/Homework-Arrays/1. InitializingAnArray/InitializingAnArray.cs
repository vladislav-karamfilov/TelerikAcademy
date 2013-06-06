using System;

class InitializingAnArray
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Allocating an array of 20 integers and initializing \neach element by its index multiplied by 5***");
        Console.Write(decorationLine);
        int[] array = new int[20];
        for (int index = 0; index < 20; index++)
        {
            array[index] = index * 5;
        }
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
