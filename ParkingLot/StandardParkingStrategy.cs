using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class StandardParkingStrategy : IParkingStrategy
    {
        public Ticket Park(IEnumerable<ParkingLot> parkingLots, Car car)
        {
            foreach (var parkingLot in parkingLots)
            {
                if (parkingLot.HasAvailablePosition())
                {
                    return parkingLot.Park(car);
                }
            }

            throw new NoAvailablePositionException();
        }

        public Car Fetch(IEnumerable<ParkingLot> parkingLots, Ticket ticket)
        {
            foreach (var parkingLot in parkingLots)
            {
                try
                {
                    return parkingLot.Fetch(ticket);
                }
                catch (UnrecognizedTicketException)
                {
                    // ignored
                }
            }

            throw new UnrecognizedTicketException();
        }
    }
}