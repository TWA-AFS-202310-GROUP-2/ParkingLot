using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingLots
    {
        private readonly int maxcapacity = 10;
        private IDictionary<Ticket, string> carTickets = new Dictionary<Ticket, string>();
        private int capacity = 0;
        public Ticket Park(string car)
        {
            if (capacity < maxcapacity)
            {
                Ticket ticket = new Ticket
                {
                    IsUsed = false,
                    TicketName = Guid.NewGuid().ToString(),
                };
                this.carTickets.Add(ticket, car);
                capacity++;
                return ticket;
            }

            return null;
        }

        public string Fetch(Ticket ticket)
        {
            if (IsValid(ticket) == "correct")
            {
                ticket.IsUsed = true; // 标记票为已使用
                return carTickets[ticket];
            }
            else
            {
                return IsValid(ticket);
            }
        }

        private string IsValid(Ticket ticket)
        {
            if (ticket.TicketName == null || !this.carTickets.ContainsKey(ticket) || ticket.IsUsed == true)
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            return "correct";
        }

        public class Ticket
        {
            public string TicketName { get; set; }
            public bool IsUsed { get; set; }
        }
    }
}
