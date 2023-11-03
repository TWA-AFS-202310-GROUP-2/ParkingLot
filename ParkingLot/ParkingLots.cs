using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingLots
    {
        private IDictionary<string, string> carTickets = new Dictionary<string, string>();
        public string Park(string car)
        {
            string ticketNumber = Guid.NewGuid().ToString();
            string ticketName = $"Ticket {ticketNumber}";
            this.carTickets.Add(ticketName, car);

            return ticketName;
        }

        public string Fetch(string ticket)
        {
            if (this.carTickets.ContainsKey(ticket))
            {
                string car = carTickets[ticket];
                return car;
            }

            return "wrong ticket";
        }
    }
}
