using System;

namespace ShapeSurfaceCalculator.Common
{
    public class Triangle : Shape
    {
        public double? Side
        {
            get { return this.width; }
            set
            {
                if (value != null && value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Triangle's side must be a positive number!");
                }
                this.width = value;
            }
        }
        public double? Height
        {
            get { return this.height; }
            set
            {
                if (value != null && value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Triangle's height must be a positive number!");
                }
                this.height = value;
            }
        }

        public Triangle()
            : this(null, null)
        {
        }
        public Triangle(double? side, double? height)
        {
            this.Side = side;
            this.Height = height;
        }

        public override double CalculateSurface()
        {
            if (this.Side == null)
            {
                throw new InvalidOperationException("No side of the triangle is provided!");
            }
            if (this.Height == null)
            {
                throw new InvalidOperationException("Not provided height to the provided side!");
            }
            return this.Side.Value * this.Height.Value / 2;
        }
    }
}
