using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static ParkingLot.ParkingLots;

namespace ParkingLot
{
    public class SmartParkingBoy
    {
        private List<ParkingLots> parkingLots;

        public Ticket Park(List<ParkingLots> parkingLots, string car)
        {
            var lotWithMostSpace = parkingLots.OrderByDescending(lot => lot.RemainingParking).FirstOrDefault();

            if (lotWithMostSpace == null)
            {
                throw new NoPositionException("No available position.");
            }

            Ticket ticket = lotWithMostSpace.Park(car);
            ticket.PakingLotName = lotWithMostSpace.Number;
            return ticket;
        }

        public string Fetch(List<ParkingLots> parkingLots, Ticket ticket)
        {
            var parkingLotWithTicket = parkingLots.FirstOrDefault(lot => lot.HasTicket(ticket));
            if (parkingLotWithTicket == null)
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            return parkingLotWithTicket.Fetch(ticket);
        }
    }
}
