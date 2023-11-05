using System.Collections.Generic;
using System.Linq;
using static ParkingLot.ParkingLots;

namespace ParkingLot
{
    public class ParkingStrategy : IParkingStrategy
    {
        private List<ParkingLots> parkingLots;
        public ParkingStrategy(List<ParkingLots> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public string Fetch(List<ParkingLots> parkingLots, Ticket ticket)
        {
            var parkingLotWithTicket = parkingLots.FirstOrDefault(lot => lot.HasTicket(ticket));
            return parkingLotWithTicket == null
                ? throw new WrongTicketException("Unrecognized parking ticket.")
                : parkingLotWithTicket.Fetch(ticket);
        }

        public virtual Ticket Park(List<ParkingLots> parkingLots, string car)
        {
            var selectedLot = parkingLots.FirstOrDefault(lot => lot.HasPosition());
            return selectedLot == null
                ? throw new NoPositionException("No available position.")
                : selectedLot.Park(car);
        }
    }
}