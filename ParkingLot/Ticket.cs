using System;
namespace ParkingLot
{
    public class Ticket
    {
        public Ticket()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}