using System;

class PointWithinOutOfACircle
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Checking if a point (x, y) is within a circle K(O, 5)***");
        Console.Write(decorationLine);
        Console.Write("Enter the point's X-coordinate: ");
        double xCoordinate = double.Parse(Console.ReadLine());
        Console.Write("Enter the point's Y-coordinate: ");
        double yCoordinate = double.Parse(Console.ReadLine());
        bool pointInCircle = ((xCoordinate * xCoordinate) + (yCoordinate * yCoordinate)) <= 25.0;
        if (pointInCircle == true)
        {
            Console.WriteLine("The point ({0}, {1}) is within the circle K(O, 5).", xCoordinate, yCoordinate);
        }
        else
        {
            Console.WriteLine("The point ({0}, {1}) is out of the circle K(O, 5).", xCoordinate, yCoordinate);
        }
    }
}
