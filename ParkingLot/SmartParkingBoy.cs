using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(IEnumerable<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public new Ticket Park(Car car)
        {
            // Order parking lots by the number of available positions in descending order
            var parkingLotWithMostSpace = ParkingLots
                .OrderByDescending(pl => pl.AvailablePositions)
                .FirstOrDefault();

            if (parkingLotWithMostSpace != null && parkingLotWithMostSpace.HasAvailablePosition())
            {
                return parkingLotWithMostSpace.Park(car);
            }

            throw new NoAvailablePositionException();
        }
    }
}
