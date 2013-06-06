using System;

class RectangleArea
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating rectangle's area***");
        Console.Write(decorationLine);
        Console.Write("Enter rectangle's height: ");
        double rectangleHeight = double.Parse(Console.ReadLine());
        Console.Write("Enter rectangle's width: ");
        double rectangleWidth = double.Parse(Console.ReadLine());
        double rectangleArea = rectangleHeight * rectangleWidth;
        Console.WriteLine("Rectangle's area is: {0}.", rectangleArea);
    }
}