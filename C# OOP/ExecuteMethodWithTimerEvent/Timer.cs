using System;
using System.Threading;

namespace ExecuteMethodWithTimerEvent
{
    public delegate void TimeElapsedEventHandler(object sender, TimeElapsedEventArgs eventArgs);

    public class Timer
    {
        public event TimeElapsedEventHandler TimeElapsed;

        private int intervalInSeconds;
        private int cyclesCount;

        public int IntervalInSeconds
        {
            get { return this.intervalInSeconds; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The interval must be a positive number!");
                }
                this.intervalInSeconds = value;
            }
        }
        public int CyclesCount
        {
            get { return this.cyclesCount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The number of cycles must be a positive number!");
                }
                this.cyclesCount = value;
            }
        }

        public Timer(int intervalInSeconds, int cyclesCount)
        {
            this.IntervalInSeconds = intervalInSeconds;
            this.CyclesCount = cyclesCount;
        }

        protected virtual void OnTimeElapsed(TimeElapsedEventArgs eventArgs)
        {
            // Creating a temporary copy of the event
            TimeElapsedEventHandler newHandler = TimeElapsed;
            if (newHandler != null)
            {
                newHandler(this, eventArgs); // Handling the event
            }
        }
        // The method to raise the event
        public void Run()
        {
            int cyclesLeft = this.cyclesCount;
            while (true)
            {
                // Raising the event with passing the call time
                OnTimeElapsed(new TimeElapsedEventArgs(DateTime.Now));
                cyclesLeft--;
                if (cyclesLeft == 0)
                {
                    break;
                }
                Thread.Sleep(this.intervalInSeconds * 1000);
            }
        }
    }
}
