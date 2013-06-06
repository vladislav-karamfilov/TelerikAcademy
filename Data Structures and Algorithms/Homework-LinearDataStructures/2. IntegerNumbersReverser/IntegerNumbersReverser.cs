using System;
using System.Collections.Generic;

class IntegerNumbersReverser
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Reversing N integer numbers***");
        Console.Write(decorationLine);

        try
        {
            Console.Write("Enter how many integers N will be entered: ");
            int inputNumbersCount = int.Parse(Console.ReadLine());
            if (inputNumbersCount <= 0)
            {
                throw new ArgumentOutOfRangeException("Input numbers count must be a positive number!");
            }

            Stack<int> inputNumbers = new Stack<int>(inputNumbersCount);
            for (int i = 0; i < inputNumbersCount; i++)
            {
                Console.Write("Enter an integer number: ");
                int inputNumber = int.Parse(Console.ReadLine());

                inputNumbers.Push(inputNumber);
            }

            Console.Write("The input integers in reversed order are: ");
            while (inputNumbers.Count > 0)
            {
                Console.Write("{0} ", inputNumbers.Pop());
            }

            Console.WriteLine();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input number! The input is not an integer!");
            return;
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.Message);
            return;
        }
    }
}