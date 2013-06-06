using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int col = startCol; col < endCol; col++)
            {
                if (col == (WorldCols - 2) / 4 || col == WorldCols / 2 || 
                    col == WorldCols - 10 || col == WorldCols - 5) // Task 12: Testing the classes Gift and GiftBlock
                {
                    engine.AddObject(new GiftBlock(new MatrixCoords(startRow, col)));
                    continue;
                }
                Block currBlock = new Block(new MatrixCoords(startRow, col));
                engine.AddObject(currBlock);
            }

            // Task 1: Creating the side walls
            for (int row = 0; row < WorldRows; row++)
            {
                IndestructibleBlock leftSideWallBlock = new IndestructibleBlock(new MatrixCoords(row, 0));
                engine.AddObject(leftSideWallBlock);
                IndestructibleBlock rightSideWallBlock = new IndestructibleBlock(new MatrixCoords(row, WorldCols - 1));
                engine.AddObject(rightSideWallBlock);
            }
            
            // Task 1: Creating the ceiling wall
            for (int col = 1; col < WorldCols - 1; col++)
            {
                IndestructibleBlock ceilingWallBlock = new IndestructibleBlock(new MatrixCoords(0, col));
                engine.AddObject(ceilingWallBlock);
            }

            // Task 10: Testing the ExplodingBlock class
            //engine.AddObject(new ExplodingBlock(new MatrixCoords(startRow + 3, startCol + 4)));
            //engine.AddObject(new ExplodingBlock(new MatrixCoords(startRow + 3, startCol + 3)));
            //engine.AddObject(new ExplodingBlock(new MatrixCoords(startRow + 3, startCol + 5)));
            //engine.AddObject(new ExplodingBlock(new MatrixCoords(startRow + 3, startCol + 7)));


            // Task 7: Replacing the normal ball with meteorite ball
            MeteoriteBall metoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            engine.AddObject(metoriteBall);

            //// Task 9: Testing the UnstoppableBall class
            //UnstoppableBall unstoppableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            //engine.AddObject(unstoppableBall);

            // Task 9: Testing the UnpassableBlock class
            for (int col = 5; col < WorldCols; col += 15)
            {
                engine.AddObject(new UnpassableBlock(new MatrixCoords(5, col)));
            }

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            ShootingRacketEngine gameEngine = new ShootingRacketEngine(renderer, keyboard, 150);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };
            // Task 13: Adding handler for shooting racket
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacker();
            };

            Initialize(gameEngine);

            //// Task 5: Testing the TrailObject class
            //char[,] testTrailObjectBody = { {'T', 'E', 'S', 'T' } };
            //gameEngine.AddObject(new TrailObject(new MatrixCoords(1, 17), testTrailObjectBody, 3));

            gameEngine.Run();
        }
    }
}
