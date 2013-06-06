using System;

class ThreeNumbers
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing the numbers 1, 101 and 1001***");
        Console.Write(decorationLine);
        Console.WriteLine("{0}\t{1}\t{2}", 1, 101, 1001);
    }
}

