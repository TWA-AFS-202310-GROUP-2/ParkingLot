using System;
using System.Runtime.Serialization;

namespace ParkingLot
{
    [Serializable]
    public class NoPositionException : Exception
    {
        public NoPositionException()
        {
        }

        public NoPositionException(string message) : base(message)
        {
        }

        public NoPositionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoPositionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}