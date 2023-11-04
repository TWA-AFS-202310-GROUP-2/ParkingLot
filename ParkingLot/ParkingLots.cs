using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingLots
    {
        private readonly int maxcapacity = 10;
        private IDictionary<Ticket, string> carTickets = new Dictionary<Ticket, string>();
        private int capacity = 0;
        private int remainingParking;

        public ParkingLots(int v)
        {
            this.maxcapacity = v;
            this.remainingParking = maxcapacity;
        }

        public ParkingLots()
        {
            remainingParking = maxcapacity;
        }

        public string Number { get; set; }
        public int RemainingParking
        {
            get
            {
                return remainingParking;
            }
        }

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
                remainingParking--;
                return ticket;
            }

            throw new NoPositionException("No available position.");
        }

        public string Fetch(Ticket ticket)
        {
            if (IsValid(ticket) == "correct")
            {
                ticket.IsUsed = true;
                return carTickets[ticket];
            }

            throw new WrongTicketException("Unrecognized parking ticket.");
        }

        public bool HasPosition()
        {
            if (capacity < maxcapacity)
            {
                return true;
            }

            return false;
        }

        public bool HasTicket(Ticket ticket)
        {
            return carTickets.ContainsKey(ticket);
        }

        private string IsValid(Ticket ticket)
        {
            if (ticket.TicketName == null || ticket.IsUsed == true || !carTickets.ContainsKey(ticket))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            return "correct";
        }

        public class Ticket
        {
            public string PakingLotName { get; set; }
            public string TicketName { get; set; }
            public bool IsUsed { get; set; }
        }
    }
}
