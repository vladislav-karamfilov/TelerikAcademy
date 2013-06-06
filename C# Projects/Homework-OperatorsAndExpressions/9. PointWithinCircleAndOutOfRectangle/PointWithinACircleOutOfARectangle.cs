using System;

class PointWithinACircleOutOfARectangle
{
    static void Main()
    {
        string decorationLine = new string('-', 80);
        Console.Write(decorationLine);
        Console.WriteLine("***Checking if a point (x, y) is within the circle K((1, 1), 3) and\nout of the rectangle R(top=1, left=-1, width=6, height=2)***");
        Console.Write(decorationLine);
        Console.Write("Enter point's x-coordinate: ");
        double xCoordinate = double.Parse(Console.ReadLine());
        Console.Write("Enter point's y-coordinate: ");
        double yCoordinate = double.Parse(Console.ReadLine());
        if ((((xCoordinate - 1) * (xCoordinate-1)) + ((yCoordinate - 1) * (yCoordinate - 1))) <= 9)
        {
            //x = 1 + 2 * Math.Sqrt(2) is where the circle crossed the abscissa 
            if ((xCoordinate >= -1) && (xCoordinate <= (1 + 2 * Math.Sqrt(2))) && (yCoordinate >= -1) && (yCoordinate <= 1))
            {
                Console.WriteLine(@"The point ({0}, {1}) is within the circle K((1, 1), 3) and
within the rectangle R(top=1, left=-1, width=6, height=2).", xCoordinate, yCoordinate);
            }
            else
            {
                Console.WriteLine(@"The point ({0}, {1}) is within the circle K((1, 1), 3) and
out of the rectangle R(top=1, left=-1, width=6, height=2).", xCoordinate, yCoordinate);
            }
        }
        else if ((xCoordinate >= -1) && (xCoordinate <= 5) && (yCoordinate >= -1) && (yCoordinate <= 1))
        {
            Console.WriteLine(@"The point ({0}, {1}) is out of the circle K((1, 1), 3) and
within the rectangle R(top=1, left=-1, width=6, height=2).", xCoordinate, yCoordinate);
        }
            else
            {
                Console.WriteLine(@"The point ({0}, {1}) is out of the circle K((1, 1), 3) and
out of the rectangle R(top=1, left=-1, width=6, height=2).", xCoordinate, yCoordinate);
        }
    }
}