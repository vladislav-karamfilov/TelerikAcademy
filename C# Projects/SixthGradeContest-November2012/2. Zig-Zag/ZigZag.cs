using System;

class ZigZag
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine()); // How many numbers the series has
        if (n != 0)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[n];
            for (byte i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }
            byte count = 1;
            byte answer = 1;
            sbyte sign = 1; // Means "+" and -1 means "-"
            for (byte i = 0; i < n - 1; i++)
            {
                if (numbers[i] < numbers[i + 1] && sign == 1)
                {
                    count++;
                    sign = -1;   
                }
                else if (numbers[i] > numbers[i + 1] && sign == -1)
                {
                    count++;
                    sign = 1;
                }
                else
                {
                    count = 1;
                }
                if (count > answer)
                {
                    answer = count;
                }
            }
            Console.WriteLine(answer);
        }
        else
        {
            return;
        }
    }
}