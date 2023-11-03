using System;
using System.Runtime.Serialization;

namespace Parking
{
    [Serializable]
    public class WrongTicketExecption : Exception
    {
        public WrongTicketExecption()
        {
        }

        public WrongTicketExecption(string message) : base(message)
        {
        }

        public WrongTicketExecption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongTicketExecption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class NoCapacityExecption : Exception
    {
        public NoCapacityExecption()
        {
        }

        public NoCapacityExecption(string message) : base(message)
        {
        }

        public NoCapacityExecption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoCapacityExecption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}