using System;

class AngryBits
{
    static int[,] grid = new int[8, 16];
    static int points = 0;
    
    static void FillGrid()
    {
        for (int row = 0; row < 8; row++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int col = 0; col < 16; col++)
            {
                grid[row, col] = (number >> col) & 1;
            }
        }
    }

    static void PrintScore()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 7; col >= 0; col--)
            {
                if (grid[row, col] == 1)
                {
                    Console.WriteLine(points + " No");
                    return;
                }
            }
        }
        Console.WriteLine(points + " Yes");
    }

    static void PrintGrid() // Just for testing the solution
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 15; col >= 0; col--)
            {
                Console.Write(grid[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void FlyDiagonallyDownwards(int row, int col, int lengthOfFlight)
    {
        int destroyedPigs = 0;
        while (row <= 7 && col >= 0 && grid[row, col] == 0)
        {
            row++;
            col--;
            lengthOfFlight++;
        }
        if (row <= 7 && col >= 0)
        {
            if (grid[row, col] == 1) // The hit pig
            {
                destroyedPigs++;
                grid[row, col] = 0;
            }
            if (row < 7 && grid[row + 1, col + 1] == 1) // The pig below diagonally left
            {
                destroyedPigs++;
                grid[row + 1, col + 1] = 0;
            }
            if (row < 7 && col > 0 && grid[row + 1, col - 1] == 1) // The pig below diagonally right
            {
                destroyedPigs++;
                grid[row + 1, col - 1] = 0;
            }
            if (row < 7 && grid[row + 1, col] == 1) // // The pig below
            {
                destroyedPigs++;
                grid[row + 1, col] = 0;
            }
            if (grid[row, col + 1] == 1) // The pig on the left
            {
                destroyedPigs++;
                grid[row, col + 1] = 0;
            }
            if (col > 0 && grid[row, col - 1] == 1) // The pig on the right
            {
                destroyedPigs++;
                grid[row, col - 1] = 0;
            }
            if (row > 0 && grid[row - 1, col + 1] == 1) // The pig upper diagonally left
            {
                destroyedPigs++;
                grid[row - 1, col + 1] = 0;
            }
            if (row > 0 && grid[row - 1, col] == 1) // The upper pig
            {
                destroyedPigs++;
                grid[row - 1, col] = 0;
            }
            if (row > 0 && col > 0 && grid[row - 1, col - 1] == 1) // The pig upper diagonally right
            {
                destroyedPigs++;
                grid[row - 1, col - 1] = 0;
            }
        }
        //PrintGrid();
        points += (destroyedPigs * lengthOfFlight);
        //Console.WriteLine(points + " points");
    }

    static void FlyDiagonallyUpwards(int row, int col, int lengthOfFlight)
    {
        int destroyedPigs = 0;
        while (row > 0 && grid[row, col] == 0)
        {
            row--;
            col--;
            lengthOfFlight++;
        }
        if (row == 0 && grid[row, col] == 0)
        {
            FlyDiagonallyDownwards(row + 1, col - 1, lengthOfFlight + 1);
            return;
        }
        if (grid[row, col] == 1) // The hit pig
        {
            destroyedPigs++;
            grid[row, col] = 0;
        }
        if (col < 7 && grid[row, col + 1] == 1) // The pig on the left
        {
            destroyedPigs++;
            grid[row, col + 1] = 0;
        }
        if (grid[row, col - 1] == 1) // The pig on the right
        {
            destroyedPigs++;
            grid[row, col - 1] = 0;
        }
        if (row > 0)
        {
            if (grid[row - 1, col + 1] == 1) // The pig upper diagonally left
            {
                destroyedPigs++;
                grid[row - 1, col + 1] = 0;
            }
            if (grid[row - 1, col] == 1) // The upper pig
            {
                destroyedPigs++;
                grid[row - 1, col] = 0;
            }
            if (grid[row - 1, col - 1] == 1) // The pig upper diagonally right
            {
                destroyedPigs++;
                grid[row - 1, col - 1] = 0;
            }
        }
        if (grid[row + 1, col + 1] == 1) // The pig below diagonally left
        {
            destroyedPigs++;
            grid[row + 1, col + 1] = 0;
        }
        if (grid[row + 1, col] == 1) // The pig below
        {
            destroyedPigs++;
            grid[row + 1, col] = 0;
        }
        if (grid[row + 1, col - 1] == 1) // The pig below diagonally right
        {
            destroyedPigs++;
            grid[row + 1, col - 1] = 0;
        }
        //PrintGrid();
        points += (destroyedPigs * lengthOfFlight);
        //Console.WriteLine(points + " points");
    }

    static void Main()
    {
        FillGrid();
        //PrintGrid();
        for (int col = 8; col < 16; col++)
        {
            for (int row = 0; row < 8; row++)
            {
                if (grid[row, col] == 0)
                {
                    continue;
                }
                if (row == 0)
                {
                    grid[row, col] = 0;
                    FlyDiagonallyDownwards(row + 1, col - 1, 1);
                    break; // There will be one bird in each column
                }
                else
                {
                    grid[row, col] = 0;
                    FlyDiagonallyUpwards(row - 1, col - 1, 1);
                    break; // There will be one bird in each column
                }
            }
        }
        PrintScore();
    }
}