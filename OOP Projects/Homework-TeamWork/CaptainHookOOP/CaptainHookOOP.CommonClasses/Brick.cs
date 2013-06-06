namespace CaptainHookOOP.CommonClasses
{
    internal class Brick : StaticObject
    {
        private static readonly char[,] image = new char[,] { { '#', '#' }, { '#', '#' } };

        public Brick(MatrixCoordinates topLeft)
            : base(topLeft)
        {
            this.Image = image;
            this.Color = Colors.Gray;
        }

        public Brick(MatrixCoordinates topLeft, Colors color)
            : this(topLeft)
        {
            this.Image = image;
            this.Color = color;
        }
    }
}