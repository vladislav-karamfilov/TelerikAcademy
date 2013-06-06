using System;

class BitBall
{
    static void Main()
    {
        char[,] grid = new char[8, 8];
        for (int row = 0; row < 8; row++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int col = 0; col < 8; col++)
            {
                if (((number >> col) & 1) == 1)
                {
                    grid[row, col] = 'T';
                }
                else
                {
                    grid[row, col] = '0';
                }
            }
        }
        for (int row = 0; row < 8; row++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int col = 0; col < 8; col++)
            {
                if (((number >> col) & 1) == 1)
                {
                    if (grid[row, col] == 'T')
                    {
                        grid[row, col] = '0';
                        continue;
                    }
                    grid[row, col] = 'B';
                }
            }
        }
        int top = 0;
        for (int row = 0; row < 8; row++)
        {
            for (byte col = 0; col < 8; col++) 
            {
                if (grid[row, col] == 'T')
                {
                    int temp = row;
                    while (temp < 7 && grid[temp + 1, col] != 'B' && grid[temp + 1, col] != 'T')
                    {
                        grid[temp + 1, col] = 'T';
                        temp++;
                    }
                }
            }
            if (row == 7)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (grid[row, col] == 'T')
                    {
                        top++;
                    }
                }
            }
        }
        int bottom = 0;
        for (int row = 7; row >= 0; row--)
        {
            for (byte col = 0; col < 8; col++)
            {
                if (grid[row, col] == 'B')
                {
                    int temp = row;
                    while (temp > 0 && grid[temp - 1, col] != 'B' && grid[temp - 1, col] != 'T')
                    {
                        grid[temp - 1, col] = 'B';
                        temp--;
                    }
                }
            }
            if (row == 0)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (grid[row, col] == 'B')
                    {
                        bottom++;
                    }
                }
            }
        }
        Console.WriteLine(top +":" +bottom);
    }
}
