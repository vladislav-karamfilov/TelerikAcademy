using System;
using System.Text;

class IsoscelesTriangleOfCopyrights
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing an isosceles triangle of 9 copyright symbols***");
        Console.Write(decorationLine);
        char copyright = '\u00A9';
        int initialSpaces = 2;
        int initialCopyrights = 1;
        for (int row = 0; row < 3; row++)
        {
            for (int spaces = initialSpaces; spaces > 0; spaces--)
            {
                Console.Write(" ");
            }
            for (int copyrights = 0; copyrights < initialCopyrights; copyrights++)
            {
                Console.Write(copyright);
            }
            Console.WriteLine();
            initialSpaces--;
            initialCopyrights += 2;
        }
    }
}