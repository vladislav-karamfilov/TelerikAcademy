namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double? width;
        private double? height;

        public Rectangle()
            : this(null, null)
        {
        }

        public Rectangle(double? width, double? height)
        {
            this.Width = width;
            this.Height = height;
        }

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

        public override double GetPerimeter()
        {
            if (this.Width == null)
            {
                throw new InvalidOperationException("Rectangle's width is not provided!");
            }

            if (this.Height == null)
            {
                throw new InvalidOperationException("Rectangle's height is not provided!");
            }

            double perimeter = 2 * (this.Width.Value + this.Height.Value);
            return perimeter;
        }

        public override double GetSurface()
        {
            if (this.Width == null)
            {
                throw new InvalidOperationException("Rectangle's width is not provided!");
            }

            if (this.Height == null)
            {
                throw new InvalidOperationException("Rectangle's height is not provided!");
            }

            double surface = this.Width.Value * this.Height.Value;
            return surface;
        }
    }
}
