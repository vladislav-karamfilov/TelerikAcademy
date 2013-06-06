using System;

namespace CaptainHookOOP.CommonClasses
{
    internal class Flag : MovingObject
    {
        private static readonly char[,] image = new char[,] { 
                             {' ',' ', ' ', '*'},
                             {' ',' ', '*', '*'},
                             {' ','*', '*', '*'},
                             {'*','*', '*', '*'} };

        public Flag(MatrixCoordinates topLeft)
            : base(topLeft)
        {
            this.Image = image;
            this.Color = Colors.Green;
            this.Speed = new MatrixCoordinates(-1, 0);
        }

        public override void Move()
        {
            this.TopLeft -= this.Speed;
        }
    }
}
