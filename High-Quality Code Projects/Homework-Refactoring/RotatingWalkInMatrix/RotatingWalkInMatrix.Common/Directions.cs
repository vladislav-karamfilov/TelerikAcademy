namespace RotatingWalkInMatrix.Common
{
    internal static class Directions
    {
        public static readonly MatrixCoordinates Southeast =
            new MatrixCoordinates(1, 1);

        public static readonly MatrixCoordinates South =
            new MatrixCoordinates(1, 0);

        public static readonly MatrixCoordinates Southwest =
            new MatrixCoordinates(1, -1);

        public static readonly MatrixCoordinates West =
            new MatrixCoordinates(0, -1);

        public static readonly MatrixCoordinates Northwest =
            new MatrixCoordinates(-1, -1);

        public static readonly MatrixCoordinates North =
            new MatrixCoordinates(-1, 0);

        public static readonly MatrixCoordinates Northeast =
            new MatrixCoordinates(-1, 1);

        public static readonly MatrixCoordinates East =
            new MatrixCoordinates(0, 1);
    }
}
