namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            Circle firstCircle = new Circle();
            firstCircle.Radius = 2.215;
            Console.WriteLine("I am a circle with radius {0}! My perimeter is {1:f2}. My surface is {2:f2}.",
                firstCircle.Radius, firstCircle.GetPerimeter(), firstCircle.GetSurface());

            Circle secondCircle = new Circle(5);
            Console.WriteLine("I am a circle with radius {0}! My perimeter is {1:f2}. My surface is {2:f2}.",
                secondCircle.Radius, secondCircle.GetPerimeter(), secondCircle.GetSurface());

            Rectangle firstRectangle = new Rectangle();
            firstRectangle.Width = 5.1;
            firstRectangle.Height = 9;
            Console.WriteLine("I am a rectangle with width {0} and height {1}! My perimeter is {2:f2}. My surface is {3:f2}.",
                firstRectangle.Width, firstRectangle.Height, firstRectangle.GetPerimeter(), firstRectangle.GetSurface());

            Rectangle secondRectangle = new Rectangle(2, 3);
            Console.WriteLine("I am a rectangle with width {0} and height {1}! My perimeter is {2:f2}. My surface is {3:f2}.",
                secondRectangle.Width, secondRectangle.Height, secondRectangle.GetPerimeter(), secondRectangle.GetSurface());
        }
    }
}
