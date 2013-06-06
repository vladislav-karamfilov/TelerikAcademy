namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private double? radius;

        public Circle()
            : this(null)
        {
        }

        public Circle(double? radius)
        {
            this.Radius = radius;
        }

        public double? Radius
        {
            get { return this.radius; }
            set
            {
                if (value != null && value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Circle's radius must be a positive number!");
                }

                this.radius = value;
            }
        }

        public override double GetPerimeter()
        {
            if (this.Radius == null)
            {
                throw new InvalidOperationException("The radius of the circle is not provided!");
            }

            double perimeter = 2 * Math.PI * this.Radius.Value;
            return perimeter;
        }

        public override double GetSurface()
        {
            if (this.Radius == null)
            {
                throw new InvalidOperationException("The radius of the circle is not provided!");
            }

            double surface = Math.PI * this.Radius.Value * this.Radius.Value;
            return surface;
        }
    }
}
