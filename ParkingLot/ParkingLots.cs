using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingLots
    {
        private string car;
        private Dictionary<string, string> ticket2Car = new Dictionary<string, string>();
        public string Fetch(string ticket)
        {
            if (ticket2Car.ContainsKey(ticket))
            {
                this.car = ticket2Car[ticket];
            }

            return this.car;
        }

        public string Park(string car)
        {
            string ticket = "T-" + car;
            ticket2Car.Add(ticket, car);
            this.car = car;
            return ticket;
        }
    }
}
