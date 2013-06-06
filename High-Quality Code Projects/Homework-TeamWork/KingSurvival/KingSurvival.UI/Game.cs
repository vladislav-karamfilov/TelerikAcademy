namespace KingSurvival.UI
{
    using System;
    using KingSurvival.Common;

    public class Game
    {
        public static void Main()
        {
            Console.Title = "King Survival v1.0   ---Team Erbium---";

            IEngine consoleEngine = new ConsoleEngine();

            consoleEngine.Run();
        }
    }
}
