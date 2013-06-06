namespace CaptainHookOOP.CommonClasses
{
    internal class Pole : StaticObject
    {
        private static readonly char[,] image = new char[,] { 
                            {' ',' ', ' ', 'O', ' ', ' ', ' ' },
                            {' ',' ', ' ', '*', ' ', ' ', ' ' },
                            {' ',' ', ' ', '*', ' ', ' ', ' ' },
                            {' ',' ', ' ', '*', ' ', ' ', ' ' },
                            {' ',' ', ' ', '*', ' ', ' ', ' ' },
                            {' ',' ', ' ', '*', ' ', ' ', ' ' },
                            {' ',' ', ' ', '*', ' ', ' ', ' ' },
                            {' ',' ', ' ', '*', ' ', ' ', ' ' },
                            {' ',' ', ' ', '*', ' ', ' ', ' ' },
                            {' ',' ', ' ', '*', ' ', ' ', ' ' },
                            {' ',' ', ' ', '*', ' ', ' ', ' ' },
                            {' ',' ', ' ', '*', ' ', ' ', ' ' },
                            {' ',' ', ' ', '*', ' ', ' ', ' ' },
                            {'#','#', '#', '#', '#', '#', '#' } };

        public Pole(MatrixCoordinates topLeft)
            : base(topLeft)
        {
            this.Image = image;
            this.Color = Colors.Cyan;
        }
    }
}
