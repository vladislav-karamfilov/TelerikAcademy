namespace CaptainHookOOP.CommonClasses
{
    internal class CastleLevel : Level
    {
        private readonly static CastleLevel finalLevel;

        private CastleLevel()
            : base()
        {
        }

        static CastleLevel()
        {
            finalLevel = new CastleLevel();
        }

        public static CastleLevel FinalLevel
        {
            get { return finalLevel; }
        }

        public override void Load(int width, int height)
        {
            LoadStaticObjects(width, height);

            base.Load(width, height);
        }

        private void LoadStaticObjects(int width, int height)
        {
            LoadLevelGround(width, height);

            // Loading castle
            finalLevel.AddObject(new Castle(new MatrixCoordinates(height - 12, width - 29)));

            // Loading pole
            finalLevel.AddObject(new Pole(new MatrixCoordinates(height - 18, width - 38)));

            // Loading flag
            finalLevel.AddObject(new Flag(new MatrixCoordinates(height - 17, width - 38)));

            LoadStairs(width, height);

            // Loading cloud
            finalLevel.AddObject(new Cloud(new MatrixCoordinates(2, width - 22), CloudImages.CloudOne));
        }

        private void LoadLevelGround(int width, int height)
        {
            for (int col = 0; col < width - 1; col += 4)
            {
                finalLevel.AddObject(new LevelGround(new MatrixCoordinates(height - 4, col)));
            }
        }

        private void LoadStairs(int width, int height)
        {
            int counter = 12;
            for (int row = height - 16; row < height - 5; row += 2, counter -= 4)
            {
                for (int col = width - (66 - counter); col < width - 50; col += 2)
                {
                    finalLevel.AddObject(new Brick(new MatrixCoordinates(row, col), Colors.DarkRed));
                }
            }
        }
    }
}
