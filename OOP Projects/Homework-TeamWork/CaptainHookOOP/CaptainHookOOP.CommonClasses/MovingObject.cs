using System;

namespace CaptainHookOOP.CommonClasses
{
    internal abstract class MovingObject : GameObjects, IMovable
    {
        private MatrixCoordinates speed;

        public MatrixCoordinates Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        protected MovingObject(MatrixCoordinates topLeft)
            : base(topLeft)
        {
        }

        public abstract void Move();

        public void RemoveFromConsole()
        {
            Console.CursorVisible = false;
            
            int imageRows = this.Image.GetLength(0);
            int imageColumns = this.Image.GetLength(1);

            for (int row = 0; row < imageRows; row++)
            {
                Console.SetCursorPosition(this.TopLeft.Column, this.TopLeft.Row + row);
                for (int col = 0; col < imageColumns; col++)
                {
                    Console.Write(' ');
                }
            }
        }
    }
}
