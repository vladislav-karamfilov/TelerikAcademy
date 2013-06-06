using System;

namespace CaptainHookOOP.CommonClasses
{
    public interface IUserInterface
    {
        event EventHandler OnLeftPressed;

        event EventHandler OnRightPressed;

        event EventHandler OnDownPressed;

        event EventHandler OnUpPressed;

        event EventHandler OnUpLeftPressed;

        event EventHandler OnUpRightPressed;

        void ProcessInput();
    }
}
