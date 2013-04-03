using System;

namespace Just3DPoint.Data
{
    public static class Two3DPointsDistance
    {
        public static double GetTwoPointsDistance(Point3D first, Point3D second)
        {
            return Math.Sqrt((first.XCoord - second.XCoord) * (first.XCoord - second.XCoord) +
                (first.YCoord - second.YCoord) * (first.YCoord - second.YCoord) +
                (first.ZCoord - second.ZCoord) * (first.ZCoord - second.ZCoord));
        }
    }
}
