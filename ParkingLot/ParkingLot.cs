namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private readonly int capacity = 10;
        private readonly HashSet<string> usedTickets = new HashSet<string>();
        private readonly Dictionary<string, string> ticketCarMap = new Dictionary<string, string>();
        private int parkingCount = 0;

        public string Park(string carNumber)
        {
            if (parkingCount >= capacity)
            {
                Console.WriteLine("No available position. Cannot park more cars.");
                return null;
            }

            var ticket = Guid.NewGuid().ToString();
            ticketCarMap[ticket] = carNumber;
            parkingCount++;

            return ticket;
        }

        public string FetchCar(string ticket = "")
        {
            if (!ticketCarMap.ContainsKey(ticket))
            {
                Console.WriteLine("Wrong ticket");
                return null;
            }

            usedTickets.Add(ticket);
            return ticketCarMap[ticket];
        }
    }
}
