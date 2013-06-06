namespace AcademyPopcorn
{
    // Task 5: Implementation of TrailObject class
    // -> inheritance of GameObject, LifeTime integer, disappearing implementation
    public class TrailObject : GameObject
    {
        public int LifeTime { get; set; }

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifeTime)
            : base(topLeft, body)
        {
            this.LifeTime = lifeTime;
        }

        public override void Update()
        {
            LifeTime--;
            if (LifeTime == 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
