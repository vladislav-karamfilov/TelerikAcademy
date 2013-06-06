using System;
class Lines
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
                if ((number & 1) != 0) // Means the bit is 1
                {
                    grid[row, col] = 1; // Filling the cell with 1 (by default it is 0)
                }
                col++; // Going to the next cell
                number >>= 1; // Removing the rightmost bit
            }
        }
        byte maxLenght = 0; 
        byte count = 0;
        // Checking by rows -> horizontal lines
        for (int row = 0; row < 8; row++)
        {
            byte lenght = 0;
            for (int col = 0; col < 8; col++)
            {
                if (grid[row, col] == 1)
                {
                    lenght++;
                    if (maxLenght < lenght)
                    {
                        maxLenght = lenght;
                        count = 0;
                    }
                    if (lenght == maxLenght)
                    {
                        count++;
                    }
                }
                else
                {
                    lenght = 0;
                }
            }
        }
        // Checking by columns -> vertical lines
        for (int col = 0; col < 8; col++)
        {
            byte lenght = 0;
            for (int row = 0; row < 8; row++)
            {
                if (grid[row, col] == 1)
                {
                    lenght++;
                    if (maxLenght < lenght)
                    {
                        maxLenght = lenght;
                        count = 0;
                    }
                    if (lenght == maxLenght)
                    {
                        count++;
                    }
                }
                else
                {
                    lenght = 0;
                }
            }
        }
        // Special case when the best line has lenght 1 (the line is counted as vertical and horizontal at the same time)
        if (maxLenght == 1)
        {
            count /= 2;
        }
        Console.WriteLine(maxLenght + "\n" + count);
    }
}