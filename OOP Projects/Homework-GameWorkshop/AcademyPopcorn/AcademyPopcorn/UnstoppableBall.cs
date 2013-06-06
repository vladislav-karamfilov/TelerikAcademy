using System.Collections.Generic;
namespace AcademyPopcorn
{
    // Task 8: Implementation of UnstoppableBall class
    public class UnstoppableBall : Ball
    {
        public new const string CollisionGroupString = "unstoppableBall";

        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body[0, 0] = '@';
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" ||
                otherCollisionGroupString == "unpassableBlock" || otherCollisionGroupString == "block";
        }
        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }
        public override void RespondToCollision(CollisionData collisionData)
        {
            List<string> collisionObjects = collisionData.hitObjectsCollisionGroupStrings;
            if (collisionObjects.Contains(IndestructibleBlock.CollisionGroupString) ||
                collisionObjects.Contains(Racket.CollisionGroupString))
            {
                base.RespondToCollision(collisionData);
            }
        }
    }
}
