using System;

namespace CaptainHookOOP.CommonClasses
{
    internal class MarioException : ApplicationException
    {
        public int Score { get; private set; }

        public MarioException(int score)
            : this(null, null, score)
        {
        }
        public MarioException(string message, int score)
            : this(message, null, score)
        {
        }
        public MarioException(string message, Exception innerException, int score)
            : base(message, innerException)
        {
            this.Score = score;
        }
    }
}
