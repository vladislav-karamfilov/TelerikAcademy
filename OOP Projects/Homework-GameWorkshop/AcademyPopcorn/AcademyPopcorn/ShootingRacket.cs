using System.Collections.Generic;

namespace AcademyPopcorn
{
    // Task 13: Implementation of ShootingRacket class
    public class ShootingRacket : Racket
    {
        private bool hasShot = false;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }

        public void Shoot()
        {
            this.hasShot = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.hasShot == true)
            {
                this.hasShot = false;
                List<Bullet> bullets = new List<Bullet>();
                bullets.Add(new Bullet(new MatrixCoords(this.TopLeft.Row - 2, this.TopLeft.Col + (this.Width / 2))));
                return bullets;
            }
            return base.ProduceObjects();
        }
    }
}
