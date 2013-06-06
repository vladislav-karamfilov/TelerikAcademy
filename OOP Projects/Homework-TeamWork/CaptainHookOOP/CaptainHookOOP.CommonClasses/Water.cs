namespace CaptainHookOOP.CommonClasses
{
    internal class Water : StaticObject
    {
        private static readonly char[,] image = new char[,] { {'-',' ','-' } };

        public Water(MatrixCoordinates topLeft)
            : base(topLeft)
        {
            this.Image = image;
            this.Color = Colors.Blue;
        }
    }
}
