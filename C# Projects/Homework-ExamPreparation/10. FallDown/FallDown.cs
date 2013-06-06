using System;

class FallDown
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
        // Repeating the algrithm described below 7 times so the full cells fall down to the bottom
        for (byte counter = 0; counter < 7; counter++)
        {
            // Taking a cell with value 1 and moving it down if the lower cell is 0
            for (byte row = 7; row > 0; row--) // Taking a row (from the bottom to the top)
            {
                for (byte col = 0; col < 8; col++) // Taking a cell
                {
                    // If the upper cell is 1 and the current cell is 0 then exchange the values
                    if (grid[row, col] == 0 && grid[row - 1, col] == 1)
                    {
                        grid[row, col] = 1;
                        grid[row - 1, col] = 0;
                    }
                }
            }
        }
        for (int row = 0; row < 8; row++)
        {
            byte numberFromRow = 0;                                         // string binaryNumber = null;
            for (int col = 7; col >= 0; col--)                              // for (int col = 7; col >= 0; col--)
            {                                                               // {
                numberFromRow += (byte)(grid[row, col] * Math.Pow(2, col)); //     binaryNumber += grid[row, col].ToString();
            }                                                               // }
            Console.WriteLine(numberFromRow);                               // Console.WriteLine(Convert.ToByte(binaryNumber, 2));
        }
    }
}
