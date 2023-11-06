using System;
using System.Runtime.Serialization;

namespace Parking
{
    [Serializable]
    public class FullCapacityException : Exception
    {
        public FullCapacityException()
        {
        }

        public FullCapacityException(string message) : base(message)
        {
        }

        public FullCapacityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FullCapacityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}