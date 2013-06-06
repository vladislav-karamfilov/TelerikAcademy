namespace KingSurvival.Common
{
    internal struct MatrixCoordinates
    {
        private int row;
        private int column;

        public MatrixCoordinates(int row, int column)
            : this()
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row
        {
            get { return this.row; }
            set { this.row = value; }
        }

        public int Column
        {
            get { return this.column; }
            set { this.column = value; }
        }

        public static bool operator ==(MatrixCoordinates first, MatrixCoordinates second)
        {
            return MatrixCoordinates.Equals(first, second);
        }

        public static bool operator !=(MatrixCoordinates first, MatrixCoordinates second)
        {
            return !MatrixCoordinates.Equals(first, second);
        }

        public static MatrixCoordinates operator +(MatrixCoordinates first, MatrixCoordinates second)
        {
            int newRow = first.Row + second.Row;
            int newColumn = first.Column + second.Column;

            MatrixCoordinates newCoordinates = new MatrixCoordinates(newRow, newColumn);
            return newCoordinates;
        }

        public static MatrixCoordinates operator -(MatrixCoordinates first, MatrixCoordinates second)
        {
            int newRow = first.Row - second.Row;
            int newColumn = first.Column - second.Column;

            MatrixCoordinates newCoordinates = new MatrixCoordinates(newRow, newColumn);
            return newCoordinates;
        }

        public override bool Equals(object other)
        {
            if (!(other is MatrixCoordinates))
            {
                return false;
            }

            MatrixCoordinates otherCoordinates = (MatrixCoordinates)other;
            return this.Row == otherCoordinates.Row && this.Column == otherCoordinates.Column;
        }

        public override int GetHashCode()
        {
            return this.Row ^ this.Column;
        }
    }
}
