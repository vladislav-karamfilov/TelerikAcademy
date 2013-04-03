using System.Collections.Generic;
using System.Text;

namespace Just3DPoint.Data
{
    public class Path
    {
        private List<Point3D> path;
        
        public Path()
        {
            this.path = new List<Point3D>();
        }
        public Path(int pointsCount)
        {
            this.path = new List<Point3D>(pointsCount);
        }
        public Path(params Point3D[] points)
        {
            this.path = new List<Point3D>(points.Length);
            foreach (Point3D point in points)
            {
                this.path.Add(point);
            }
        }

        public void AddPoint(Point3D point)
        {
            this.path.Add(point);
        }
        public void RemovePoint(Point3D point)
        {
            this.path.Remove(point);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (Point3D point in path)
            {
                result.Append(point.ToString());
            }
            return result.ToString();
        }
    }
}
