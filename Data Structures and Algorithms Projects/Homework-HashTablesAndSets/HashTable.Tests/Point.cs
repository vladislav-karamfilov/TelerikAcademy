namespace HashTable.Tests
{
    /// <summary>
    /// This is a test class to test collisions.
    /// </summary>
    internal class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Point objAsPoint = obj as Point;
            if (objAsPoint == null)
            {
                return false;
            }

            return this.X == objAsPoint.X && this.Y == objAsPoint.Y;
        }

        public override int GetHashCode()
        {
            return this.X + this.Y;
        }
    }
}
