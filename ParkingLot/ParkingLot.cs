namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        public readonly int Capacity;
        public readonly Dictionary<Ticket, Car> ParkedCars;

        public ParkingLot(int capacity)
        {
            this.Capacity = capacity;
            ParkedCars = new Dictionary<Ticket, Car>();
        }

        public Ticket Park(Car car)
        {
            if (car == null)
            {
                return null;
            }

            if (ParkedCars.Count >= Capacity)
            {
                throw new NoPositionException("No available position.");
            }

            var ticket = new Ticket();
            ParkedCars.Add(ticket, car);
            return ticket;
        }

        public Car Fetch(Ticket ticket)
        {
            if (ticket == null || !ParkedCars.TryGetValue(ticket, out var car))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            ParkedCars.Remove(ticket);
            return car;
        }
    }
}
