using System;
using System.Runtime.Serialization;

namespace ParkingLot
{
    [Serializable]
    public class UnAvailablePositionException : Exception
    {
        public UnAvailablePositionException()
        {
        }

        public UnAvailablePositionException(string message) : base(message)
        {
        }

        public UnAvailablePositionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnAvailablePositionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}