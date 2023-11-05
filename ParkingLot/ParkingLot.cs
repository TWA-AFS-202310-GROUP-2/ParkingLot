using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLot
    {
        private readonly int capacity;
        private readonly Dictionary<Ticket, Car> parkedCars;

        public ParkingLot(int capacity)
        {
            this.capacity = capacity;
            this.parkedCars = new Dictionary<Ticket, Car>();
        }

        public Ticket Park(Car car)
        {
            if (this.parkedCars.Count >= this.capacity || car == null)
            {
                throw new NoAvailablePositionException();
            }

            var ticket = new Ticket();
            this.parkedCars.Add(ticket, car);
            return ticket;
        }

        public Car Fetch(Ticket ticket)
        {
            if (ticket == null || !this.parkedCars.TryGetValue(ticket, out var car))
            {
                throw new UnrecognizedTicketException();
            }

            this.parkedCars.Remove(ticket);
            return car;
        }

        public bool HasAvailablePosition()
        {
            return this.parkedCars.Count < this.capacity;
        }
    }
}
