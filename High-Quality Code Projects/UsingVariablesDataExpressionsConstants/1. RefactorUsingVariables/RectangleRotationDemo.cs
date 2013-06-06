using System;

class RectangleRotationDemo
{
    static void Main()
    {
        Rectangle rectangleToRotate = new Rectangle(5, 6);
        double angleToRotate = Math.PI / 3;

        Rectangle rotatedRectangle = GetRotatedRectangle(rectangleToRotate, angleToRotate);
        Console.WriteLine("The width of the new rectangle is: " + rotatedRectangle.Width);
        Console.WriteLine("The height of the new rectangle is: " + rotatedRectangle.Height);
    }

    public static Rectangle GetRotatedRectangle(Rectangle rectangleToRotate, double angleInRadians)
    {
        double cosineOfAngleToRotate = Math.Cos(angleInRadians);
        double absoluteCosineOfAngleToRotate = Math.Abs(cosineOfAngleToRotate);

        double sineOfAngleToRotate = Math.Sin(angleInRadians);
        double absoluteSineOfAngleToRotate = Math.Abs(sineOfAngleToRotate);

        double rectangleToRotateWidth = rectangleToRotate.Width;
        double rectangleToRotateHeight = rectangleToRotate.Height;

        double rotatedRectangleWidth = absoluteCosineOfAngleToRotate * rectangleToRotateWidth + 
            absoluteSineOfAngleToRotate * rectangleToRotateHeight;
        double rotatedRectangleHeight = absoluteSineOfAngleToRotate * rectangleToRotateWidth +
            absoluteCosineOfAngleToRotate * rectangleToRotateHeight;

        Rectangle rotatedRectangle = new Rectangle(rotatedRectangleWidth, rotatedRectangleHeight);
        return rotatedRectangle;
    }
}

public class Rectangle
{
    public double Width { get; private set; }
    public double Height { get; private set; }

    public Rectangle(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }
}