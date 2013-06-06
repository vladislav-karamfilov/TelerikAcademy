namespace KingSurvival.Common
{
    internal class Pawn
    {
        private readonly char symbol;
        private MatrixCoordinates coordinates;

        public Pawn(char symbol, MatrixCoordinates coordinates)
        {
            this.symbol = symbol;
            this.coordinates = coordinates;
        }

        public char Symbol
        {
            get { return this.symbol; }
        }

        public MatrixCoordinates Coordinates
        {
            get { return this.coordinates; }
            set { this.coordinates = value; }
        }
    }
}
