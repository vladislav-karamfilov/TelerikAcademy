using System;

class Trapezoid
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        char symbol1 = '.';
        char symbol2 = '*';
        int leftBorderPosition = 0;
        for (int row = 0; row < n + 1; row++)
        {
            leftBorderPosition = n - row; // Positioning the left border of the trepezoid
            for (int position = 0; position < 2 * n; position++)
            {
                if (row == 0 && position < n) // First row first half
                {
                    Console.Write(symbol1);
                }
                else if (row == 0 && position >= n) // First row second half
                {
                    Console.Write(symbol2);
                }
                else if (row == n) // Last row
                {
                    Console.Write(symbol2);
                }
                else if (position == leftBorderPosition || position == 2 * n - 1) // Left and right borders
                {
                    Console.Write(symbol2);
                }
                else
                {
                    Console.Write(symbol1); // Inside and outside the trapezoid
                }
            }
            Console.WriteLine();
        }
    }
}