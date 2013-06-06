using System;

namespace CaptainHookOOP.CommonClasses
{
    internal class Mario : MovingObject
    {
        private static readonly char[,] image1 = new char[,] { { 'o', ' ' }, { '|', ' ' }, { '|', '\\' } };
        private static readonly char[,] image2 = new char[,] { { ' ', 'o' }, { ' ', '|' }, { '/', '|' } };

        public string Profile
        {
            set
            {
                if (value == "right")
                {
                    this.Image = image1;
                }
                if (value == "left")
                {
                    this.Image = image2;
                }
            }
        }

        public Mario(MatrixCoordinates topLeft, MarioImages image)
            : base(topLeft)
        {
            if ((int)image == 0) // Right turned Mario
            {
                this.Image = image1;
            }
            else // Left turned Mario
            {
                this.Image = image2;
            }
        }

        public override void Move()
        {
            this.TopLeft += this.Speed;
        }
    }
}
