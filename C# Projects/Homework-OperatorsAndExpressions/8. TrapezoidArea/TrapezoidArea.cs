using System;

class TrapezoidArea
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating trapezoid's area by the two bases and the height***");
        Console.Write(decorationLine);
        Console.Write("Enter the first base: ");
        double firstBase = double.Parse(Console.ReadLine());
        Console.Write("Enter the other base: ");
        double secondBase = double.Parse(Console.ReadLine());
        Console.Write("Enter the height: ");
        double height = double.Parse(Console.ReadLine());
        double trapezoidArea = (firstBase + secondBase) * height / 2;
        Console.WriteLine("The area of trapezoid with bases {0} and {1} and height {2} is {3}.", firstBase, secondBase, height, trapezoidArea);
    }
}
