using System;

class TwoSymetricalTriangles
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        char symbol1 = '*';
        char symbol2 = '|';
        byte numberOfAsterisks = 0;
        for (int row = 0; row < n + 1; row++)
        {
            for (int position = 0; position < 2 * n + 3; position++) // The bottom line has maximum 2 * n + 3 symbols
            {                                                        // (two triangles, two spaces and one '|')
                if (position == n + 1) // The center of the row [== (2 * n + 3) / 2]
                {
                    Console.Write(" " + symbol2);
                }
                if (position > n - numberOfAsterisks && position < n + 1 || position > n + 1 && position < n + 2 + numberOfAsterisks)
                {
                    Console.Write(symbol1);
                }
                else if (position != 0) // To prevent printing interval on the first position - not necessary
                {
                    Console.Write(" ");
                }
            }
            numberOfAsterisks++;
            Console.WriteLine();
        }
    }
}
