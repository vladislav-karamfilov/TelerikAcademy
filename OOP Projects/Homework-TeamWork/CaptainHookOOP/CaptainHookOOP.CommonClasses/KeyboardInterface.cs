using System;

namespace CaptainHookOOP.CommonClasses
{
    public class KeyboardInterface : IUserInterface
    {
        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;

        public event EventHandler OnUpLeftPressed;

        public event EventHandler OnUpRightPressed;

        public event EventHandler OnDownPressed;

        public event EventHandler OnUpPressed;

        public void ProcessInput()
        {
            if (Console.KeyAvailable == true)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (keyPressed.Key == ConsoleKey.A)
                {
                    this.OnLeftPressed(this, new EventArgs());
                }
                else if (keyPressed.Key == ConsoleKey.D)
                {
                    this.OnRightPressed(this, new EventArgs());
                }
                else if (keyPressed.Key == ConsoleKey.W)
                {
                    this.OnUpPressed(this, new EventArgs());
                }
                else if (keyPressed.Key == ConsoleKey.S)
                {
                    this.OnDownPressed(this, new EventArgs());
                }
                else if (keyPressed.Key == ConsoleKey.Q)
                {
                    this.OnUpLeftPressed(this, new EventArgs());
                }
                else if (keyPressed.Key == ConsoleKey.E)
                {
                    this.OnUpRightPressed(this, new EventArgs());
                }
            }
        }

    }
}
