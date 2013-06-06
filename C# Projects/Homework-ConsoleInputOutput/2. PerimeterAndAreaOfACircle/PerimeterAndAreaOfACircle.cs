using System;
using System.Threading;
using System.Globalization;

class PerimeterAndAreaOfACircle
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Calculating the perimeter and the area of a circle with radius R***");
        Console.Write(decorationLine);
        Console.Write("Enter the radius R of the circle: ");
        double circleRadius = double.Parse(Console.ReadLine().Replace(',', '.'));
        double circlePerimeter = 2 * Math.PI * circleRadius;
        double circleArea = Math.PI * circleRadius * circleRadius;
        Console.WriteLine("The perimeter of the circle with radius R = {0} is\n{1} and its area is {2}.",
            circleRadius, circlePerimeter, circleArea);
    }
}
