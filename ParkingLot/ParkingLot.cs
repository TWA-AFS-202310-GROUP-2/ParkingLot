namespace Parking
{
    using System;
    using System.Collections.Generic;
    using System.Net.Sockets;

    public class ParkingLot
    {
        private readonly int capacity = 10;
        private readonly Dictionary<string, string> ticketCarMap = new Dictionary<string, string>();
        private int parkingCount = 0;

        public ParkingLot()
        {
        }

        public ParkingLot(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public string Park(string carNumber)
        {
            if (parkingCount >= capacity)
            {
                throw new FullCapacityException("No available position.");
            }

            var ticket = $"{Name}-{Guid.NewGuid()}";
            ticketCarMap[ticket] = carNumber;
            parkingCount++;

            return ticket;
        }

        public string FetchCar(string ticket = null)
        {
            if (ticket == null)
            {
                return null;
            }

            if (!ticketCarMap.ContainsKey(ticket))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            var carNumber = ticketCarMap[ticket];
            ticketCarMap.Remove(ticket);
            parkingCount--;

            return carNumber;
        }

        public int GetAvailableSpaces()
        {
            return capacity - parkingCount;
        }

        public bool IsContainTheCar(string ticket)
        {
            return ticketCarMap.ContainsKey(ticket);
        }

        public bool IsFull()
        {
            return parkingCount >= capacity;
        }
    }
}
