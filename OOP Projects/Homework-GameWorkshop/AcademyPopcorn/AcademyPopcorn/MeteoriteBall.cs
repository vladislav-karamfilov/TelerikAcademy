using System.Collections.Generic;

namespace AcademyPopcorn
{
    // Task 6: Implementation of MeteoriteBall class
    // -> inheritance of Ball, 
    public class MeteoriteBall : Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<TrailObject> producedObjects = new List<TrailObject>();
            char[,] trailObjectBody = { { '.' } };
            TrailObject trailObject = new TrailObject(base.topLeft, trailObjectBody, 3);
            producedObjects.Add(trailObject);
            return producedObjects;
        }
    }
}
