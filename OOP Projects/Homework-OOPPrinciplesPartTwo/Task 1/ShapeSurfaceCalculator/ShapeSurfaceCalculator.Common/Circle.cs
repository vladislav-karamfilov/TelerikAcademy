using System;

namespace ShapeSurfaceCalculator.Common
{
    public class Circle : Shape
    {
        public double? Radius
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Circle's radius must be a positive number!");
                }
                this.width = value;
                this.height = value;
            }
        }

        public Circle(double? radius)
        {
            this.Radius = radius;
        }
        public Circle()
            : this(null)
        {
        }

        public override double CalculateSurface()
        {
            if (this.Radius == null)
            {
                throw new InvalidOperationException("The radius of the circle is not provided!");
            }
            return this.Radius.Value * this.Radius.Value * Math.PI;
        }
    }
}
