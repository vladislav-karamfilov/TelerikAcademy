using System.Collections.Generic;

namespace AcademyPopcorn
{
    // Task 11: Implementation of Gift class
    public class Gift : MovingObject
    {
        public new const string CollisionGroupString = "gift";

        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '♥' } }, new MatrixCoords(1, 0))
        {
        }

        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Racket.CollisionGroupString;
        }
        
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed == true)
            {
                List<ShootingRacket> shootingRackets = new List<ShootingRacket>();
                shootingRackets.Add(new ShootingRacket(new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col), 6));
                return shootingRackets;
            }
            return base.ProduceObjects();
        }
    }
}
