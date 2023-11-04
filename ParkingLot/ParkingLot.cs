namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private readonly int capacity;
        private readonly Dictionary<Ticket, Car> parkedCars;

        public ParkingLot(int capacity)
        {
            this.capacity = capacity;
            parkedCars = new Dictionary<Ticket, Car>();
        }

        public Ticket Park(Car car)
        {
            if (parkedCars.Count >= capacity || car == null)
            {
                return null;
            }

            var ticket = new Ticket();
            parkedCars.Add(ticket, car);
            return ticket;
        }

        public Car Fetch(Ticket ticket)
        {
            if (ticket == null || !parkedCars.TryGetValue(ticket, out var car))
            {
                return null;
            }

            parkedCars.Remove(ticket);
            return car;
        }
    }
}
