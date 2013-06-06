using System;
using ShapeSurfaceCalculator.Common;

namespace ShapeSurfaceCalculator.UI
{
    class ShapeSurfaceCalculatorDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Calculating the surfaces of different geometric shapes***");
            Console.Write(decorationLine);

            // Defining dimensions after constructing
            Triangle triangle = new Triangle();
            triangle.Side = 4.22;
            triangle.Height = 12.3;
            Rectangle rectangle = new Rectangle();
            rectangle.Height = 4.1;
            rectangle.Width = 11.2;
            Circle circle = new Circle();
            circle.Radius = 6.3;
            Shape[] shapes = new Shape[]
            {
                triangle,
                rectangle,
                circle,
                // Defining dimensions in the constructors
                new Triangle(2, 9),
                new Circle(7.8),
                new Rectangle(5.3, 4)
            };

            // Printing the surfaces of the figures
            foreach (Shape shape in shapes)
            {
                Console.WriteLine("{0,-15} {1}", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}
