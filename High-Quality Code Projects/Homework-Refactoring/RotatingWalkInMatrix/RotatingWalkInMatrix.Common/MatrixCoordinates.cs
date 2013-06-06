namespace RotatingWalkInMatrix.Common
{
    internal struct MatrixCoordinates
    {
        public MatrixCoordinates(int row, int column)
            : this()
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public static MatrixCoordinates operator +(MatrixCoordinates first, MatrixCoordinates second)
        {
            int newCoordinatesRow = first.Row + second.Row;
            int newCoordinatesColumn = first.Column + second.Column;
            MatrixCoordinates newCoordinates = new MatrixCoordinates(newCoordinatesRow, newCoordinatesColumn);
            return newCoordinates;
        }

        public static MatrixCoordinates operator -(MatrixCoordinates first, MatrixCoordinates second)
        {
            int newCoordinatesRow = first.Row - second.Row;
            int newCoordinatesColumn = first.Column - second.Column;
            MatrixCoordinates newCoordinates = new MatrixCoordinates(newCoordinatesRow, newCoordinatesColumn);
            return newCoordinates;
        }

        public static bool operator ==(MatrixCoordinates first, MatrixCoordinates second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(MatrixCoordinates first, MatrixCoordinates second)
        {
            return !first.Equals(second);
        }

        public override bool Equals(object obj)
        {
            MatrixCoordinates other = (MatrixCoordinates)obj;
            return this.Row == other.Row && this.Column == other.Column;
        }

        public override int GetHashCode()
        {
            return this.Row * 7 + this.Column;
        }
    }
}
