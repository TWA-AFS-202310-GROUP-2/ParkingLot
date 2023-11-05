using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private readonly List<ParkingLot> parkingLots;

        public ParkingBoy(IEnumerable<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots.ToList();
        }

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLots = new List<ParkingLot> { parkingLot };
        }

        public Ticket Park(Car car)
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

        public Car Fetch(Ticket ticket)
        {
            foreach (var parkingLot in parkingLots)
            {
                try
                {
                    return parkingLot.Fetch(ticket);
                }
                catch (UnrecognizedTicketException)
                {
                    // Continue checking the next parking lot
                }
            }

            throw new UnrecognizedTicketException();
        }
    }
}
