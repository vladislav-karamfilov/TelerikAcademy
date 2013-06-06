using System;

namespace ExecuteMethodWithTimerEvent
{
    public class TimeElapsedEventArgs : EventArgs
    {
        private readonly DateTime dateTimeNow;

        public DateTime DateTimeNow
        {
            get { return this.dateTimeNow; }
        }

        public TimeElapsedEventArgs(DateTime dateTimeNow)
        {
            this.dateTimeNow = dateTimeNow;
        }
    }
}
