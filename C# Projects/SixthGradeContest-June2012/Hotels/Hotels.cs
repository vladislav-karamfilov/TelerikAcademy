using System;

class Hotels
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ');
        byte[] heights = new byte[n];
        for (int i = 0; i < n; i++)
        {
            heights[i] = byte.Parse(input[i]);
        }
        byte num1 = 0;
        byte highest = 0;
        for (byte i = 0; i < n; i++)
        {
            if (highest < heights[i])
            {
                highest = heights[i];
                num1++;
            }
        }
        byte num2 = 0;
        highest = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (highest < heights[i])
            {
                highest = heights[i];
                num2++;
            }
        }
        Console.WriteLine(num1 + " " + num2);
    }
}
