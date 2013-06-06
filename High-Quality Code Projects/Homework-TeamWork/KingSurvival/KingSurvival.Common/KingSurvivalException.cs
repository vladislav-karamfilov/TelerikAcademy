namespace KingSurvival.Common
{
    using System;

    internal class KingSurvivalException : ApplicationException
    {
        public KingSurvivalException()
            : this(null, null)
        {
        }

        public KingSurvivalException(string message)
            : this(message, null)
        {
        }

        public KingSurvivalException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
