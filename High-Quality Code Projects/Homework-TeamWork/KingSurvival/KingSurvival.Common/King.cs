namespace KingSurvival.Common
{
    internal class King : Pawn
    {
        private const char KingSymbol = 'K';

        public King(MatrixCoordinates coordinates)
            : base(KingSymbol, coordinates)
        {
        }
    }
}
