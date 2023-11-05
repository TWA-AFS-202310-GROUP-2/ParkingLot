using System;
namespace ParkingLot
{
    public class UnrecognizedTicketException : Exception
    {
        public UnrecognizedTicketException() : base("Unrecognized parking ticket.")
        {
        }
    }

    public class NoAvailablePositionException : Exception
    {
        public NoAvailablePositionException() : base("No available position.")
        {
        }
    }
}