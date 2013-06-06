using System;

class Pillars
{
    static void Main()
    {
        byte[,] grid = new byte[8, 8];
        // Filling the grid with 0s and 1s according to the entered numbers
        for (byte row = 0; row < 8; row++)
        {
            byte number = byte.Parse(Console.ReadLine());
            byte col = 0;
            while (number != 0)
            {
                if ((number & 1) == 1)
                {
                    grid[row, col] = 1;
                }
                number >>= 1;
                col++;
            }
        }
        int leftmostPillar = -1;
        byte count = 0; // Counting the full cells at the left and at the right side of the pillar
        for (byte pillarPosition = 0; pillarPosition < 8; pillarPosition++)
        {
            byte count1 = 0; // Counting the full cells at the right side of the pillar
            for (byte col = 0; col < pillarPosition; col++)
            {
                for (byte row = 0; row < 8; row++)
                {
                    if (grid[row, col] == 1)
                    {
                        count1++;
                    }
                }
            }
            byte count2 = 0; // Counting the full cells at the left side of the pillar
            for (byte col = (byte)(pillarPosition + 1); col < 8; col++)
            {
                for (byte row = 0; row < 8; row++)
                {
                    if (grid[row, col] == 1)
                    {
                        count2++;
                    }
                }
            }
            if (count1 == count2)
            {
                leftmostPillar = pillarPosition;
                count = count1;
            }
        }
        if (leftmostPillar == -1) // There's no pillar such that the full cells at the right and the left side of it are equal
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine(leftmostPillar + "\n" + count);
        }
    }
}
