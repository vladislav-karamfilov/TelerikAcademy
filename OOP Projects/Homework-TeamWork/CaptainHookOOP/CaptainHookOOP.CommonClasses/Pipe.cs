namespace CaptainHookOOP.CommonClasses
{
    internal class Pipe : StaticObject
    {
        private static readonly char[,] image = new char[,]{ 
                             {'*','*','*','*','*','*','*','*','*','*'},
                             {'*','*','*','*','*','*','*','*','*','*'},
                             {' ',' ','*','*','*','*','*','*',' ',' '},
                             {' ',' ','*','*','*','*','*','*',' ',' '},
                             {' ',' ','*','*','*','*','*','*',' ',' '} };

        public Pipe(MatrixCoordinates topLeft)
            : base(topLeft)
        {
            this.Image = image;
            this.Color = Colors.Green;
        }
    }
}
