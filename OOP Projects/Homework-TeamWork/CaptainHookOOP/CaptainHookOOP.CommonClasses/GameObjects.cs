using System;

namespace CaptainHookOOP.CommonClasses
{
    internal abstract class GameObjects : IConsolePrintable
    {
        private char[,] image;
        private MatrixCoordinates topLeft;
        private Colors color;

        public char[,] Image
        {
            get { return image; }
            protected set { image = value; }
        }
        public MatrixCoordinates TopLeft
        {
            get { return topLeft; }
            set { topLeft = value; }
        }
        public Colors Color
        {
            get { return color; }
            protected set { color = value; }
        }

        protected GameObjects(MatrixCoordinates topLeft)
        {
            this.TopLeft = topLeft;
            this.Image = image;
            this.Color = color;
        }

        public void PrintOnConsole()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), this.Color.ToString());

            int imageRows = this.Image.GetLength(0);
            int imageColumns = this.Image.GetLength(1);

            for (int row = 0; row < imageRows; row++)
            {
                Console.SetCursorPosition(this.TopLeft.Column, this.TopLeft.Row + row);
                for (int col = 0; col < imageColumns; col++)
                {
                    Console.Write(this.Image[row, col]);
                }
            }
        }
    }
}
