namespace CaptainHookOOP.CommonClasses
{
    internal class BonusLevel : Level
    {
        private readonly static BonusLevel moneyLevel;

        private BonusLevel()
            : base()
        {
        }

        static BonusLevel()
        {
            moneyLevel = new BonusLevel();
        }

        public static BonusLevel MoneyLevel
        {
            get { return moneyLevel; }
        }

        public override void Load(int width, int height)
        {
            LoadStaticObjects(width, height);

            base.Load(width, height);
        }

        private void LoadStaticObjects(int width, int height)
        {
            LoadBricks(width, height);

            LoadLevelGround(width, height);

            LoadPlatform(width, height);

            LoadMoney(width, height);

            // Loading the pipe
            moneyLevel.AddObject(new Pipe(new MatrixCoordinates(height - 9, width - 24)));
        }

        private void LoadMoney(int width, int height)
        {
            // Loading money above the platform
            for (int row = height - 16; row < height - 13; row++)
            {
                for (int col = width - 60; col < width - 40; col++)
                {
                    moneyLevel.AddObject(new Coin(new MatrixCoordinates(row, col)));
                }
            }

            // Loading money on the right of the pipe
            for (int row = height - 8; row < height - 4; row += 2)
            {
                for (int col = width - 12; col < width - 4; col += 2)
                {
                    moneyLevel.AddObject(new Coin(new MatrixCoordinates(row, col)));
                }
            }
        }

        private void LoadPlatform(int width, int height)
        {
            int counter = 8;
            for (int row = height - 10; row < height - 4; row += 2, counter -= 4)
            {
                for (int col = width - (70 - counter); col < width - (30 + counter); col += 2)
                {
                    moneyLevel.AddObject(new Brick(new MatrixCoordinates(row, col), Colors.DarkRed));
                }
            }
        }

        private void LoadLevelGround(int width, int height)
        {
            for (int col = 0; col < width - 1; col += 4)
            {
                moneyLevel.AddObject(new LevelGround(new MatrixCoordinates(height - 4, col)));
            }
        }

        private void LoadBricks(int width, int height)
        {
            for (int row = 0; row < height - 3; row += 2)
            {
                for (int col = 0; col < width; col += 2)
                {
                    if (row == 0)
                    {
                        if (col != 2 && col != 4 && col != 6)
                        {
                            moneyLevel.AddObject(new Brick(new MatrixCoordinates(row, col)));
                        }
                    }
                    else 
                    {
                        if (col == 0 || col == width - 2)
                        {
                            moneyLevel.AddObject(new Brick(new MatrixCoordinates(row, col)));
                        }
                    }
                }
            }
        }
    }
}

