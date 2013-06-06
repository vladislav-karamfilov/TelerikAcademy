using System.Linq;

namespace CaptainHookOOP.CommonClasses
{
    internal class OutsideLevel : Level
    {
        private readonly static OutsideLevel aboveGround;

        private OutsideLevel()
            : base()
        {
        }

        static OutsideLevel()
        {
            aboveGround = new OutsideLevel();
        }

        public static OutsideLevel AboveGround
        {
            get { return aboveGround; }
        }

        public override void Load(int width, int height)
        {
            LoadStaticObjects(width, height);

            base.Load(width, height);
        }

        private void LoadStaticObjects(int width, int height)
        {
            LoadLevelGround(width, height);

            // Loading pipe
            aboveGround.AddObject(new Pipe(new MatrixCoordinates(height - 9, width - 15)));

            LoadBricks(width, height);

            // Loading clouds
            aboveGround.AddObject(new Cloud(new MatrixCoordinates(1, 10), CloudImages.CloudOne));
            aboveGround.AddObject(new Cloud(new MatrixCoordinates(1, 50), CloudImages.CloudTwo));

            LoadCoinsOverBricks(width, height);

            // Loading coins on the right of the pipe
            aboveGround.AddObject(new Coin(new MatrixCoordinates(height - 6, width - 3)));
            aboveGround.AddObject(new Coin(new MatrixCoordinates(height - 6, width - 5)));

            LoadWater(width, height);
        }

        private void LoadWater(int width, int height)
        {
            for (int col = 0; col < width - 3; col += 4)
            {
                aboveGround.AddObject(new Water(new MatrixCoordinates(height - 1, col)));
            }
        }

        private void LoadCoinsOverBricks(int width, int height)
        {
            for (int col = width - 40; col < width - 27; col += 2)
            {
                aboveGround.AddObject(new Coin(new MatrixCoordinates(height - 16, col)));
            }
        }

        private void LoadBricks(int width, int height)
        {
            for (int col = width - 46; col < width - 22; col += 2)
            {
                aboveGround.AddObject(new Brick(new MatrixCoordinates(height - 12, col), Colors.DarkRed));
            }
        }

        private void LoadLevelGround(int width, int height)
        {
            for (int col = 0; col < width - 1; col += 4)
            {
                if (col == 20 || col == 24)
                {
                    continue;
                }
                aboveGround.AddObject(new LevelGround(new MatrixCoordinates(height - 4, col)));
            }
        }
    }
}
