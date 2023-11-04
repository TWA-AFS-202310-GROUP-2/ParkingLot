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
            if (car == null)
            {
                return null;
            }

            if (parkedCars.Count >= capacity)
            {
                throw new NoPositionException("No available position.");
            }

            var ticket = new Ticket();
            parkedCars.Add(ticket, car);
            return ticket;
        }

        public Car Fetch(Ticket ticket)
        {
            if (ticket == null || !parkedCars.TryGetValue(ticket, out var car))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            parkedCars.Remove(ticket);
            return car;
        }
    }
}
