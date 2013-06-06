namespace Just3DPoint.Data
{
    public struct Point3D
    {
        public double XCoord { get; set; }
        public double YCoord { get; set; }
        public double ZCoord { get; set; }

        private static readonly Point3D coordSystemStart = new Point3D(0, 0, 0);
        public static Point3D CoordSystemStart
        {
            get { return coordSystemStart; }
        }

        public Point3D(double xCoord, double yCoord, double zCoord)
            : this()
        {
            this.XCoord = xCoord;
            this.YCoord = yCoord;
            this.ZCoord = zCoord;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", this.XCoord, this.YCoord, this.ZCoord);
        }
    }
}
