namespace CohesionAndCoupling
{
    using System;

    public class RectangularCuboid
    {
        private double width;
        private double height;
        private double depth;

        public RectangularCuboid(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Cuboid's width must be a positive number!");
                }

                this.width = value;
            }
        }

        public double Height 
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Cuboid's height must be a positive number!");
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get { return this.depth; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Cuboid's depth must be a positive number!");
                }

                this.depth = value;
            }
        }

        public double CalculateVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalculateDiagonalXYZ()
        {
            double distance = GeometryUtils.CalculateDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalculateDiagonalXY()
        {
            double distance = GeometryUtils.CalculateDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalculateDiagonalXZ()
        {
            double distance = GeometryUtils.CalculateDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalculateDiagonalYZ()
        {
            double distance = GeometryUtils.CalculateDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}
