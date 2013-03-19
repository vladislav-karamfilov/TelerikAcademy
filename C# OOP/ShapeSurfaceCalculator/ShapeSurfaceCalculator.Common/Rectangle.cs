using System;

namespace ShapeSurfaceCalculator.Common
{
    public class Rectangle : Shape
    {
        public double? Width
        {
            get { return this.width; }
            set
            {
                if (value != null && value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Rectangle's width must be a positive number!");
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
                    throw new ArgumentOutOfRangeException("Rectangle's height must be a positive number!");
                }
                this.height = value;
            }
        }

        public Rectangle()
            : this(null, null)
        {
        }
        public Rectangle(double? width, double? height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double CalculateSurface()
        {
            if (this.Width == null)
            {
                throw new InvalidOperationException("Rectangle's width is not provided!");
            }
            if (this.Height == null)
            {
                throw new InvalidOperationException("Rectangle's height is not provided!");
            }
            return this.Width.Value * this.Width.Value;
        }
    }
}
