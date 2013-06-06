using System;
using System.Threading;

namespace ExecuteMethodWithTimer
{
    public delegate void TimeElapsedMethodCall();

    public class Timer
    {
        private TimeElapsedMethodCall callbackMethod;

        public TimeElapsedMethodCall CallbackMethod
        {
            get { return this.callbackMethod; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Theres is no provided method for the timer instance!");
                }
                this.callbackMethod = value;
            }
        }
        
        public Timer(TimeElapsedMethodCall callbackMethod)
        {
            this.CallbackMethod = callbackMethod;
        }

        public void Run(int intervalInSeconds, int cycles)
        {
            if (intervalInSeconds <= 0)
            {
                throw new ArgumentOutOfRangeException("The interval must be a positive number!");
            }
            if (cycles <= 0)
            {
                throw new ArgumentOutOfRangeException("The number of cycles must be a positive number!");
            }
            while (true)
            {
                callbackMethod();
                cycles--;
                if (cycles == 0)
                {
                    break;
                }
                Thread.Sleep(intervalInSeconds * 1000);
            }
        }
    }
}
