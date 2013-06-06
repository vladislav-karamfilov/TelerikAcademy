using System;
using System.Threading;

namespace CaptainHookOOP.CommonClasses
{
    public class ConsoleEngine : IEngine
    {
        internal static Level CurrentLevel { get; private set; }
        internal static Mario Player { get; private set; }
        internal static int Score { get; set; }

        private int sleepTime;
        private readonly IUserInterface userInterface;
        public MovementManager MovementManager { get; private set; }

        public int SleepTime
        {
            get { return this.sleepTime; }
            set { this.sleepTime = value; }
        }

        public ConsoleEngine(IUserInterface userInterface, int sleepTime)
        {
            this.userInterface = userInterface;
            this.SleepTime = sleepTime;
            this.MovementManager = new MovementManager();
            CurrentLevel = OutsideLevel.AboveGround;
            Player = new Mario(new MatrixCoordinates(Console.WindowHeight - 7, 0), MarioImages.RightProfile);
        }

        public void Run()
        {
            try
            {
                CurrentLevel.Load(Console.WindowWidth, Console.WindowHeight);
                CurrentLevel.PrintStaticObjects();

                while (true)
                {
                    this.userInterface.ProcessInput();

                    CurrentLevel.AddObject(Player);

                    if (Player.TopLeft.Row + 2 == Console.WindowHeight - 2)
                    {
                        throw new MarioException("Game over!!!", Score);
                    }

                    CurrentLevel.PrintMovingObjects();
                    Thread.Sleep(sleepTime);
                    CurrentLevel.RemoveMovingObjects();
                }
            }
            catch (MarioException marioException)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                
                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
                Console.WriteLine(marioException.Message);

                Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2 + 1);
                Console.WriteLine("Your score: {0}", marioException.Score);

                Console.ReadKey(true);
            }
        }

        internal static void ChangeLevel()
        {
            Console.Clear();

            if (CurrentLevel is OutsideLevel)
            {
                CurrentLevel = BonusLevel.MoneyLevel;
                Player.TopLeft = new MatrixCoordinates(Console.WindowHeight - 8, 3);
            }
            else if (CurrentLevel is BonusLevel)
            {
                CurrentLevel = CastleLevel.FinalLevel;
                Player.TopLeft = new MatrixCoordinates(Console.WindowHeight - 8, 0);
            }

            CurrentLevel.Load(Console.WindowWidth, Console.WindowHeight);
            CurrentLevel.PrintStaticObjects();
        }
    }
}
