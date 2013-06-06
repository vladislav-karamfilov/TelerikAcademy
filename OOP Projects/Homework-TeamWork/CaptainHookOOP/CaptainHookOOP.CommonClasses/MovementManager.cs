using System;

namespace CaptainHookOOP.CommonClasses
{
    public class MovementManager : IMovementManager
    {
        public virtual void MovePlayerLeft()
        {
            ConsoleEngine.Player.Profile = "left";

            MatrixCoordinates leftSpeed = new MatrixCoordinates(0, -1);
            MatrixCoordinates newTopLeft = ConsoleEngine.Player.TopLeft + leftSpeed;

            if (IsInVisibleField(newTopLeft, Console.WindowWidth, Console.WindowHeight))
            {
                if (CheckMovingLeft(newTopLeft))
                {
                    ConsoleEngine.Player.Speed = leftSpeed;
                    ConsoleEngine.Player.Move();
                    while (!HasSurfaceBelow(newTopLeft + new MatrixCoordinates(0, 1)))
                    {
                        this.MovePlayerDown();
                        newTopLeft.Row++;
                    }
                }
            }
        }

        public virtual void MovePlayerRight()
        {
            ConsoleEngine.Player.Profile = "right";

            MatrixCoordinates rightSpeed = new MatrixCoordinates(0, 1);
            MatrixCoordinates newTopLeft = ConsoleEngine.Player.TopLeft + rightSpeed;

            if (IsInVisibleField(newTopLeft, Console.WindowWidth, Console.WindowHeight))
            {
                if (CheckMovingRight(newTopLeft))
                {
                    ConsoleEngine.Player.Speed = rightSpeed;
                    ConsoleEngine.Player.Move();
                    while (!HasSurfaceBelow(newTopLeft))
                    {
                        this.MovePlayerDown();
                        newTopLeft.Row++;
                    }
                }
            }
        }

        public virtual void MovePlayerUp()
        {
            MatrixCoordinates upSpeed = new MatrixCoordinates(-1, 0);
            MatrixCoordinates newTopLeft = ConsoleEngine.Player.TopLeft + upSpeed;

            if (IsInVisibleField(newTopLeft, Console.WindowWidth, Console.WindowHeight))
            {
                if (CheckMovingUp(newTopLeft))
                {
                    ConsoleEngine.Player.Speed = upSpeed;
                    ConsoleEngine.Player.Move();
                }
            }
        }

        public virtual void MovePlayerDown()
        {
            MatrixCoordinates downSpeed = new MatrixCoordinates(1, 0);
            MatrixCoordinates newTopLeft = ConsoleEngine.Player.TopLeft + downSpeed;

            if (IsInVisibleField(newTopLeft, Console.WindowWidth, Console.WindowHeight))
            {
                if (CheckMovingDown(newTopLeft))
                {
                    ConsoleEngine.Player.Speed = downSpeed;
                    ConsoleEngine.Player.Move();
                }
            }
        }

        public virtual void MovePlayerUpLeft()
        {
            ConsoleEngine.Player.Profile = "left";

            MatrixCoordinates upLeftSpeed = new MatrixCoordinates(-1, -1);
            MatrixCoordinates newTopLeft = ConsoleEngine.Player.TopLeft + upLeftSpeed;

            if (IsInVisibleField(newTopLeft, Console.WindowWidth, Console.WindowHeight))
            {
                if (CheckMovingLeft(newTopLeft) && CheckMovingUp(newTopLeft))
                {
                    ConsoleEngine.Player.Speed = upLeftSpeed;
                    ConsoleEngine.Player.Move();
                }
            }
        }

        public virtual void MovePlayerUpRight()
        {
            ConsoleEngine.Player.Profile = "right";

            MatrixCoordinates upRightSpeed = new MatrixCoordinates(-1, 1);
            MatrixCoordinates newTopLeft = ConsoleEngine.Player.TopLeft + upRightSpeed;

            if (IsInVisibleField(newTopLeft, Console.WindowWidth, Console.WindowHeight))
            {
                if (CheckMovingUp(newTopLeft) && CheckMovingRight(newTopLeft))
                {
                    ConsoleEngine.Player.Speed = upRightSpeed;
                    ConsoleEngine.Player.Move();
                }
            }
        }

        private bool IsInVisibleField(MatrixCoordinates newTopLeft, int width, int height)
        {
            return newTopLeft.Row >= 0 && newTopLeft.Row + ConsoleEngine.Player.Image.GetLength(0) < height &&
                            newTopLeft.Column >= 0 && newTopLeft.Column + ConsoleEngine.Player.Image.GetLength(1) < width;
        }

        private bool CheckMovingLeft(MatrixCoordinates newTopLeft)
        {
            char currentLevelGridSymbol = new char();

            for (int row = newTopLeft.Row; row < newTopLeft.Row + 3; row++)
            {
                currentLevelGridSymbol = ConsoleEngine.CurrentLevel.LevelGrid[row, newTopLeft.Column];

                if (currentLevelGridSymbol == '$')
                {
                    ConsoleEngine.Score += 100;
                    ConsoleEngine.CurrentLevel.LevelGrid[row, newTopLeft.Column] = ' ';
                    continue;
                }

                if (ConsoleEngine.CurrentLevel is CastleLevel && currentLevelGridSymbol == '*')
                {
                    throw new MarioException("You win!!!", ConsoleEngine.Score);
                }

                if (currentLevelGridSymbol != default(char) && currentLevelGridSymbol != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckMovingRight(MatrixCoordinates newTopLeft)
        {
            char currentLevelGridSymbol = new char();

            for (int row = newTopLeft.Row; row < newTopLeft.Row + 3; row++)
            {
                currentLevelGridSymbol = ConsoleEngine.CurrentLevel.LevelGrid[row, newTopLeft.Column + 1];

                if (currentLevelGridSymbol == '$')
                {
                    ConsoleEngine.Score += 100;
                    ConsoleEngine.CurrentLevel.LevelGrid[row, newTopLeft.Column + 1] = ' ';
                    continue;
                }

                if (ConsoleEngine.CurrentLevel is CastleLevel && currentLevelGridSymbol == '*')
                {
                    throw new MarioException("You win!!!", ConsoleEngine.Score);
                }

                if (currentLevelGridSymbol != default(char) && currentLevelGridSymbol != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckMovingUp(MatrixCoordinates newTopLeft)
        {
            char currentLevelGridSymbol = new char();
            for (int col = newTopLeft.Column; col < newTopLeft.Column + 2; col++)
            {
                currentLevelGridSymbol = ConsoleEngine.CurrentLevel.LevelGrid[newTopLeft.Row, col];

                if (currentLevelGridSymbol == '$')
                {
                    ConsoleEngine.Score += 100;
                    ConsoleEngine.CurrentLevel.LevelGrid[newTopLeft.Row, col] = ' ';
                    continue;
                }

                if (ConsoleEngine.CurrentLevel is CastleLevel && currentLevelGridSymbol == '*')
                {
                    throw new MarioException("You win!!!", ConsoleEngine.Score);
                }

                if (currentLevelGridSymbol != default(char) && currentLevelGridSymbol != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckMovingDown(MatrixCoordinates newTopLeft)
        {
            char currentLevelGridSymbol = new char();

            for (int col = newTopLeft.Column; col < newTopLeft.Column + 2; col++)
            {
                currentLevelGridSymbol = ConsoleEngine.CurrentLevel.LevelGrid[newTopLeft.Row + 2, col];

                if (currentLevelGridSymbol == '$')
                {
                    ConsoleEngine.Score += 100;
                    ConsoleEngine.CurrentLevel.LevelGrid[newTopLeft.Row + 2, col] = ' ';
                    continue;
                }

                if (currentLevelGridSymbol == '*')
                {
                    if (ConsoleEngine.CurrentLevel is CastleLevel)
                    {
                        throw new MarioException("You win!!!", ConsoleEngine.Score);
                    }
                    ConsoleEngine.ChangeLevel();
                }

                if (currentLevelGridSymbol != default(char) && currentLevelGridSymbol != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private bool HasSurfaceBelow(MatrixCoordinates newTopLeft)
        {
            if (newTopLeft.Row + 2 == Console.WindowHeight - 1)
            {
                throw new MarioException("Game over!", ConsoleEngine.Score);
            }

            if (ConsoleEngine.CurrentLevel.LevelGrid[newTopLeft.Row + 1, newTopLeft.Column] != default(char) &&
                    ConsoleEngine.CurrentLevel.LevelGrid[newTopLeft.Row + 1, newTopLeft.Column] != ' ')
            {
                return true;
            }
            return false;
        }
    }
}
