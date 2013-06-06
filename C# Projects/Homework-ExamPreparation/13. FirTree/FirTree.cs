using System;

class FirTree
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        char symbol1 = '.';
        char symbol2 = '*';
        byte asterisks = 1;
        for (byte row = 0; row < n; row++)
        {
            for (int position = 0; position < 2 * n - 3; position++)
            {
                if (row == 0 || row == n - 1)
                {
                    if (position == (2 * n - 3) / 2) // The middle of the row
                    {
                        Console.Write(symbol2);
                    }
                    else
                    {
                        Console.Write(symbol1);
                    }
                }
                else if (position == (2 * n - 3 - asterisks) / 2) // The half of the '*' are on the left of the
                {                                                 // center of the row and the other half are on the right of it
                    for (int i = 0; i < asterisks; i++)
                    {
                        Console.Write(symbol2);
                    }
                    position += asterisks - 1; // Positioning right after the last '*'
                }
                else
                {
                    Console.Write(symbol1);
                }
            }
            asterisks += 2; // Each row has 2 '*'-s more than the previous one
            Console.WriteLine();
        }
    }
}
