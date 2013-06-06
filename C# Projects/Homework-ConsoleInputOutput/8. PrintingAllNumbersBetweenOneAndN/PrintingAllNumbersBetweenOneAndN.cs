using System;

class PrintingAllNumbersBetweenOneAndN
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Printing all the integers between 1 and N***");
        Console.Write(decorationLine);
        Console.Write("Enter N: ");
        uint n = uint.Parse(Console.ReadLine());
        Console.WriteLine("All the integers between 1 and {0} are: ", n);
        for (uint i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}
