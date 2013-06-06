using System.Collections.Generic;

namespace AcademyPopcorn
{
    // Task 12: Implementation of GiftBlock class (drops a gift when the block is destroyed)
    public class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = 'G';
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return true;
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
                List<Gift> gifts = new List<Gift>();
                gifts.Add(new Gift(this.TopLeft));
                return gifts;
            }
            return base.ProduceObjects();
        }
    }
}
