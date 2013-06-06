namespace AcademyPopcorn
{
    // Task 10: Implementation of ExplosionParticle class which is the product of an explosion
    public class ExplosionParticle : MovingObject
    {
        public ExplosionParticle(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { '+' } }, speed)
        {
        }

        public override void Update()
        {
            this.IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Block.CollisionGroupString;
        }
    }
}
