using System;
using System.Runtime.Serialization;

namespace GenericInvalidRangeException
{
    [Serializable()]
    public class InvalidRangeException<T> : ApplicationException
    {
        public T Start
        {
            get;
            private set;
        }
        public T End
        {
            get;
            private set;
        }

        public InvalidRangeException(T start, T end)
            : this(null, start, end, null)
        {
        }
        public InvalidRangeException(string message, T start, T end)
            : this(message, start, end, null)
        {
        }
        public InvalidRangeException(string message, T start, T end, Exception innerException)
            : base(message, innerException)
        {
            this.Start = start;
            this.End = end;
        }
        // Constructor for serializing the exception
        protected InvalidRangeException(SerializationInfo information, StreamingContext context)
        {
        }

        public override string ToString()
        {
            return string.Format("The value is out of the range [{0}..{1}]!", this.Start, this.End);
        }
    }
}
