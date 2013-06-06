using System.Collections.Generic;

namespace AcademyPopcorn
{
    // Task 10: Implementation of ExplodingBlock class
    public class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
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
                List<ExplosionParticle> expolosionParticles = new List<ExplosionParticle>();
                expolosionParticles.Add(new ExplosionParticle(this.TopLeft, new MatrixCoords(-1, 1)));
                expolosionParticles.Add(new ExplosionParticle(this.TopLeft, new MatrixCoords(-1, 0)));
                expolosionParticles.Add(new ExplosionParticle(this.TopLeft, new MatrixCoords(-1, -1)));
                expolosionParticles.Add(new ExplosionParticle(this.TopLeft, new MatrixCoords(0, -1)));
                expolosionParticles.Add(new ExplosionParticle(this.TopLeft, new MatrixCoords(0, 1)));
                expolosionParticles.Add(new ExplosionParticle(this.TopLeft, new MatrixCoords(1, 1)));
                expolosionParticles.Add(new ExplosionParticle(this.TopLeft, new MatrixCoords(1, 0)));
                expolosionParticles.Add(new ExplosionParticle(this.TopLeft, new MatrixCoords(1, -1)));
                return expolosionParticles;
            }
            return base.ProduceObjects();
        }
    }
}
