using System;

class SandGlass
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        char symbol1 = '.';
        char symbol2 = '*';
        byte asterisks = n;
        for (byte row = 0; row < n; row++)
        {
            for (byte position = 0; position < n; position++)
            {
                if (row < n / 2 && position == row)
                {
                    for (byte i = 0; i < asterisks; i++)
                    {
                        Console.Write(symbol2);
                    }
                    position += (byte)(asterisks - 1); // Positioning right after the last '*'
                    asterisks -= 2; // The row below has 2 asterisks less than the current row
                }
                else if (row == n / 2 && position == n / 2) // The middle of the sand-glass
                {
                    Console.Write(symbol2);
                    asterisks += 2; // The row below has 2 asterisks more than the current row
                }
                else if (row > n / 2 && position == n - row - 1)
                {
                    for (byte i = 0; i < asterisks; i++)
                    {
                        Console.Write(symbol2);
                    }
                    position += (byte)(asterisks - 1); // Positioning right after the last '*'
                    asterisks += 2; // The row below has 2 asterisks more than the current row
                }
                else
                {
                    Console.Write(symbol1); // Where there is no '*'
                }
            }
            Console.WriteLine();
        }
    }
}
