using System;
// Needs a lot of improvement - time and taking in caution that the number can be one odd times...
class OddNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long[] numbers = new long[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());
        }
        for (byte i = 0; i < n - 1; i++)
        {
            for (byte j = (byte)(i + 1); j < n; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    numbers[i] = 0;
                    numbers[j] = 0;
                }
            }
        }
        for (byte i = 0; i < n; i++)
        {
            if (numbers[i] != 0)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
