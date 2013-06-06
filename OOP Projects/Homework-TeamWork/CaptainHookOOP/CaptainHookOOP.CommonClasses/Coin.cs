namespace CaptainHookOOP.CommonClasses
{
    internal class Coin : StaticObject
    {
        private static readonly char[,] image = new char[,] { { '$' } };

        public Coin(MatrixCoordinates topLeft)
            : base(topLeft)
        {
            this.Image = image;
            this.Color = Colors.Green;
        }
    }
}
