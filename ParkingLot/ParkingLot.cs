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
                return null;
            }

            var ticket = new Ticket();
            this.parkedCars.Add(ticket, car);
            return ticket;
        }

        public Car Fetch(Ticket ticket)
        {
            if (ticket == null || !this.parkedCars.TryGetValue(ticket, out var car))
            {
                return null;
            }

            this.parkedCars.Remove(ticket);
            return car;
        }
    }

    public class Car
    {
    }

    public class Ticket
    {
        public Ticket()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
