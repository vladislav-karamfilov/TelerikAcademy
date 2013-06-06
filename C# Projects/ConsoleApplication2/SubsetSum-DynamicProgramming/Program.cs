using System;
/// <summary>
///  Needs improvement (20/100 in BGCODER)!!! Doesn't work with negative numbers
/// </summary>
class SubsetSum
{
    static void Main()
    {
        long sum = long.Parse(Console.ReadLine());
        byte n = byte.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        long negativeSum = 0;
        long positiveSum = 0;
        for (byte i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
            if (numbers[i] < 0)
            {
                negativeSum += numbers[i];
            }
            else if (numbers[i] > 0)
            {
                positiveSum += numbers[i];
            }
        }
        long length = 1;
        if (negativeSum != 0)
        {
            length += Math.Abs(negativeSum);
        }
        length += sum + positiveSum;
        long[,] array = new long[2, length];
        for (long i = 0; i < length; i++)
        {
            array[0, i] = negativeSum + i;
        }
        foreach (long number in numbers)
        {
            for (long i = length - 1; i >= 0; i--)
            {
                if (array[1, i] != 0 && i + number >= 0)
                {
                    array[1, i + number]++;
                }
            }
            if (number <= sum)
            {
                array[1, number + Math.Abs(negativeSum)]++;
            }
        }
        for (int i = 0; i < length; i++)
        {
            Console.Write(array[1, i] + " ");
        }
    }
}