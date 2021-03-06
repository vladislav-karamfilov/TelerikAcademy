﻿namespace CaptainHookOOP.CommonClasses
{
    internal class Cloud : StaticObject
    {
        private static readonly char[,] image1 = new char[,] { 
                                                    {' ',' ','§','§','§','§','§','§','§','§','§','§','§','§',' ',' '},
                                                    {' ','§','§','§','§','§','§','§','§','§','§','§','§','§','§',' '},
                                                    {'§','§','§','§','§','§','§','§','§','§','§','§','§','§','§','§'},
                                                    {'§','§','§','§','§','§','§','§','§','§','§','§','§','§','§','§'},
                                                    {' ','§','§','§','§','§','§','§','§','§','§','§','§','§','§',' '},
                                                    {' ',' ','§','§','§','§','§','§','§','§','§','§','§','§',' ',' '} };

        private static readonly char[,] image2 = new char[,] {
                                                    {' ',' ','§','§','§','§','§','§',' ',' '},
                                                    {' ','§','§','§','§','§','§','§','§',' '},
                                                    {'§','§','§','§','§','§','§','§','§','§'},
                                                    {' ','§','§','§','§','§','§','§','§',' '},
                                                    {' ',' ','§','§','§','§','§','§',' ',' '} };

        public Cloud(MatrixCoordinates topLeft, CloudImages cloudImage)
            : base(topLeft)
        {
            if ((int)cloudImage == 0)
            {
                this.Image = image1;
            }
            else
            {
                this.Image = image2;
            }
            this.Color = Colors.Cyan;
        }
    }
}
