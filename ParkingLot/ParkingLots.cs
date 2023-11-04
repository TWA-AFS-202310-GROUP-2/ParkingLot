using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingLots : IParkingLot
    {
        private string? car;
        private string? ticket;
        private int capacity = 10;
        private int maxCapacity = 10;
        private Dictionary<string?, string?> ticket2Car = new Dictionary<string?, string?>();
        public ParkingLots(int capacity)
        {
            this.capacity = capacity;
            ticket2Car = new Dictionary<string?, string?>();
        }

        public ParkingLots()
        {
            ticket2Car = new Dictionary<string?, string?>();
        }

        public int PositionCapacity()
        {
            return this.capacity;
        }

        public string Fetch(string ticket)
        {
            //if (ticket2Car.ContainsKey(ticket))
            //if (ticket == null)
            //{
            //    return null;
            //}

            if (ticket == null || !ticket2Car.ContainsKey(ticket))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            this.car = ticket2Car[ticket];
            ticket2Car.Remove(ticket);
            this.capacity++;
            return this.car;
        }

        public string Park(string car)
        {
            this.ticket = "T-" + car;
            this.capacity--;

            if (this.capacity < 0)
            {
                throw new UnAvailablePositionException("No available position.");
            }
            else
            {
                ticket2Car.Add(this.ticket, car);
                this.car = car;
                return this.ticket;
            }
        }

        public bool HasAvailableSpace()
        {
            return (this.capacity < this.maxCapacity) && (this.capacity > 0);
        }
    }
}
