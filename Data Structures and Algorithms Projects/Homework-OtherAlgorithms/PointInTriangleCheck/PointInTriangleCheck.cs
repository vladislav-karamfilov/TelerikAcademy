using System;
using System.Collections.Generic;

class PointInTriangleCheck
{
    static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Checking if a point P is in the triangle formed by points A, B and C***");
        Console.Write(decorationLine);

        Point pointA;
        Point pointB;
        Point pointC;
        ReadPoints(out pointA, out pointB, out pointC);

        if (CanFormTriangle(pointA, pointB, pointC))
        {
            Console.Write("Enter x-coordinate of point P to be checked: ");
            double xCoordinate = double.Parse(Console.ReadLine());
            Console.Write("Enter y-coordinate of point P to be checked: ");
            double yCoordinate = double.Parse(Console.ReadLine());
            Point pointP = new Point(xCoordinate, yCoordinate);
            if (PointIsInTriangle(pointP, pointA, pointB, pointC))
            {
                Console.WriteLine("Point {0} is in the triangle formed by points {1}, {2} and {3}!",
                    pointP, pointA, pointB, pointC);
            }
            else
            {
                Console.WriteLine("Point {0} is not in the triangle formed by points {1}, {2} and {3}!",
                    pointP, pointA, pointB, pointC);
            }
        }
        else
        {
            Console.WriteLine("Points {0}, {1} and {2} cannot form a triangle!",
                pointA, pointB, pointC);
        }
    }

    static bool PointIsInTriangle(Point pointP, Point pointA, Point pointB, Point pointC)
    {
        double nominator = (pointB.Y - pointC.Y) * (pointP.X - pointC.X) + (pointC.X - pointB.X) * (pointP.Y - pointC.Y);
        double denominator = (pointB.Y - pointC.Y) * (pointA.X - pointC.X) + (pointC.X - pointB.X) * (pointA.Y - pointC.Y);
        double lambda1 = nominator / denominator;

        nominator = (pointC.Y - pointA.Y) * (pointP.X - pointC.X) + (pointA.X - pointC.X) * (pointP.Y - pointC.Y);
        denominator = (pointB.Y - pointC.Y) * (pointA.X - pointC.X) + (pointC.X - pointB.X) * (pointA.Y - pointC.Y);
        double lambda2 = nominator / denominator;

        double lambda3 = 1 - lambda1 - lambda2;

        return 0 < lambda1 && lambda1 < 1 && 
               0 < lambda2 && lambda2 < 1 && 
               0 < lambda3 && lambda3 < 1;
    }

    static bool CanFormTriangle(Point pointA, Point pointB, Point pointC)
    {
        double slopeOfAB = (pointB.Y - pointA.Y) / (pointB.X - pointA.X);
        double slopeOfAC = (pointC.Y - pointA.Y) / (pointC.X - pointA.X);

        return slopeOfAB != slopeOfAC;
    }

    static void ReadPoints(out Point pointA, out Point pointB, out Point pointC)
    {
        double xCoordinate = 0;
        double yCoordinate = 0;

        Console.Write("Enter x-coordinate of point A: ");
        xCoordinate = double.Parse(Console.ReadLine());
        Console.Write("Enter y-coordinate of point A: ");
        yCoordinate = double.Parse(Console.ReadLine());
        pointA = new Point(xCoordinate, yCoordinate);

        Console.Write("Enter x-coordinate of point B: ");
        xCoordinate = double.Parse(Console.ReadLine());
        Console.Write("Enter y-coordinate of point B: ");
        yCoordinate = double.Parse(Console.ReadLine());
        pointB = new Point(xCoordinate, yCoordinate);

        Console.Write("Enter x-coordinate of point C: ");
        xCoordinate = double.Parse(Console.ReadLine());
        Console.Write("Enter y-coordinate of point C: ");
        yCoordinate = double.Parse(Console.ReadLine());
        pointC = new Point(xCoordinate, yCoordinate);
    }
}

struct Point
{
    public Point(double x, double y)
        : this()
    {
        this.X = x;
        this.Y = y;
    }

    public double X { get; set; }

    public double Y { get; set; }

    public override string ToString()
    {
        return string.Format("[{0}, {1}]", this.X, this.Y);
    }
}
