namespace CaptainHookOOP.CommonClasses
{
    internal class LevelGround : StaticObject
    {
        private static readonly char[,] image = new char[,] { 
                                            {'#','#','#','#'},
                                            {'#','#','#','#'},
                                            {'#','#','#','#'} };

        public LevelGround(MatrixCoordinates topLeft)
            : base(topLeft)
        {
            this.Image = image;
            this.Color = Colors.Gray;
        }
    }
}
