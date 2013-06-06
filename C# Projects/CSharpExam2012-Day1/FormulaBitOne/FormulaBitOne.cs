using System;

class FormulaBitOne
{
    static void Main()
    {
        int[,] grid = new int[8, 8];
        for (int i = 0; i < 8; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++)
            {
                grid[i, j] = (number >> j) & 1;
            }
        }
        if (grid[0, 0] == 1) // The first entered number is odd so the upper right corner is full
        {
            Console.WriteLine("No " + "0");
            return;
        }
        int lenght = 0;
        int turns = 0;
        int row = 0;
        int col = 0;
        bool flag = false; // Needed if south-west-north-west is not enough to reach the bottom left cell
        while (true)
        {
            if (flag)
            {
                turns++;
            }
            while (row <= 7 && grid[row, col] == 0) // Moving south
            {
                lenght++;
                row++;
            }
            row--; // Returning the row on the right track
            if (row == 7 && col == 7 && grid[row, col] == 0)
            {
                Console.WriteLine(lenght + " " + turns);
                return;
            }
            if (col < 7)
            {
                col++; // Preparing for the next sector of the track
            }
            if (grid[row, col] == 1) // The neighbour cell is full
            {
                Console.WriteLine("No " + lenght);
                return;
            }
            turns++;
            while (col <= 7 && grid[row, col] == 0) // Moving west
            {
                lenght++;
                col++;
            }
            col--; // Returning the col on the right track
            if (row == 7 && col == 7 && grid[row, col] == 0)
            {
                Console.WriteLine(lenght + " " + turns);
                return;
            }
            if (row > 0)
            {
                row--; // Preparing for the next sector of the track
            }
            if (grid[row, col] == 1) // The neighbour cell is full
            {
                Console.WriteLine("No " + lenght);
                return;
            }
            turns++;
            while (row >= 0 && grid[row, col] == 0) // Moving up
            {
                lenght++;
                row--;
            }
            row++; // Returning the row on the right track
            if (col < 7)
            {
                col++; // Preparing for the next sector of the track
            }
            else // The upper left cell is reached and the track cannot continue because the next direction is west
            {
                Console.WriteLine("No " + lenght);
                return;
            }
            if (grid[row, col] == 1)
            {
                Console.WriteLine("No " + lenght);
                return;
            }
            turns++;
            while (col <= 7 && grid[row, col] == 0) // Moving west
            {
                lenght++;
                col++;
            }
            col--; // Returning the col on the right track
            flag = true;
            lenght--; // Decrementing the lenght because otherwise one cell is counted twice
        }
    }
}
