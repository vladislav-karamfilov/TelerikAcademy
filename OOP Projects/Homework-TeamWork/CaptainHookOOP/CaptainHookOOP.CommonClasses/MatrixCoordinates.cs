namespace CaptainHookOOP.CommonClasses
{
    internal struct MatrixCoordinates
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public MatrixCoordinates(int row, int column)
            : this()
        {
            this.Row = row;
            this.Column = column;
        }

        public override bool Equals(object other)
        {
            if (!(other is MatrixCoordinates))
            {
                return false;
            }
            MatrixCoordinates otherCoordinates = (MatrixCoordinates)other;
            if (this.Row == otherCoordinates.Row && this.Column == otherCoordinates.Column)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Row ^ this.Column;
        }

        public static MatrixCoordinates operator +(MatrixCoordinates coordinates1, MatrixCoordinates coordinates2)
        {
            MatrixCoordinates newCoordinates =
                new MatrixCoordinates(coordinates1.Row + coordinates2.Row, coordinates1.Column + coordinates2.Column);
            return newCoordinates;
        }

        public static MatrixCoordinates operator -(MatrixCoordinates coordinates1, MatrixCoordinates coordinates2)
        {
            MatrixCoordinates newCoordinates =
                new MatrixCoordinates(coordinates1.Row - coordinates2.Row, coordinates1.Column - coordinates2.Column);
            return newCoordinates;
        }

        public static bool operator ==(MatrixCoordinates coordinates1, MatrixCoordinates coordinates2)
        {
            return MatrixCoordinates.Equals(coordinates1, coordinates2);
        }

        public static bool operator !=(MatrixCoordinates coordinates1, MatrixCoordinates coordinates2)
        {
            return !MatrixCoordinates.Equals(coordinates1, coordinates2);
        }
    }
}
