using System;

class TenNumbersInIncreasingOrder
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Reading 10 numbers in increasing order from 1 to 100 and handling \nexceptions***");
        Console.Write(decorationLine);
        try
        {
            int currentNumber = 1;
            int[] numbers = new int[10];
            for (int count = 0; count < 10; count++)
            {
                numbers[count] = ReadNumber(currentNumber, 100);
                currentNumber = numbers[count];
            }
            Console.WriteLine("The entered numbers in increasing order are: ");
            PrintNumbers(numbers);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("The entered number is not in the range!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number! The input is not an integer number!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number is too big or too small!");
        }
    }

    static void PrintNumbers(int[] numbers)
    {
        for (int index = 0; index < numbers.Length; index++)
        {
            if (index == 9)
            {
                Console.WriteLine(numbers[index]);
            }
            else
            {
                Console.Write(numbers[index] + " < ");
            }
        }
    }

    static int ReadNumber(int start, int end)
    {
        Console.Write("Enter a number in the range ({0}..{1}): ", start, end);
        int number = int.Parse(Console.ReadLine());
        if (number <= start || number >= end)
        {
            throw new ArgumentOutOfRangeException();
        }
        return number;
    }
}
