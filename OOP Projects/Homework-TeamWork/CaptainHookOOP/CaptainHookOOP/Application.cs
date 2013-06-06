using System;
using CaptainHookOOP.CommonClasses;

namespace CaptainHookOOP
{
    class Application
    {
        static void Main()
        {
            RemoveConsoleScrollBars();

            IUserInterface keyboard = new KeyboardInterface();
            ConsoleEngine engine = new ConsoleEngine(keyboard, 100);

            ProcessKeyboardEvents(keyboard, engine);

            engine.Run();
        }

        private static void ProcessKeyboardEvents(IUserInterface keyboard, ConsoleEngine engine)
        {
            keyboard.OnUpPressed += (sender, eventInfo) =>
            {
                engine.MovementManager.MovePlayerUp();
            };

            keyboard.OnDownPressed += (sender, eventInfo) =>
            {
                engine.MovementManager.MovePlayerDown();
            };

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                engine.MovementManager.MovePlayerLeft();
            };

            keyboard.OnUpLeftPressed += (sender, eventInfo) =>
            {
                engine.MovementManager.MovePlayerUpLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                engine.MovementManager.MovePlayerRight();
            };

            keyboard.OnUpRightPressed += (sender, eventInfo) =>
            {
                engine.MovementManager.MovePlayerUpRight();
            };
        }

        private static void RemoveConsoleScrollBars()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }
    }
}
