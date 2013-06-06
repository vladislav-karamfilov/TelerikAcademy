using System;

class MinAndMaxOfTwoIntegers
{
    static void Main()
    {
        int a = 313123;
        int b = 158449;
        int min = b + ((a - b) & ((a - b) >> (sizeof(int) * 8 - 1)));
        int max = a - ((a - b) & ((a - b) >> (sizeof(int) * 8 - 1)));
        Console.WriteLine("Min: " + min);
        Console.WriteLine("Max: " + max);
    }
}
