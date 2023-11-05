using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SmartParkingStrategy : IParkingStrategy
    {
    public Ticket Park(IEnumerable<ParkingLot> parkingLots, Car car)
    {
        var parkingLotWithMostSpace = parkingLots.OrderByDescending(pl => pl.AvailablePositions).FirstOrDefault();
        if (parkingLotWithMostSpace != null && parkingLotWithMostSpace.HasAvailablePosition())
        {
            return parkingLotWithMostSpace.Park(car);
        }

        throw new NoAvailablePositionException();
    }

    public Car Fetch(IEnumerable<ParkingLot> parkingLots, Ticket ticket)
    {
        return new StandardParkingStrategy().Fetch(parkingLots, ticket); // Fetch strategy remains the same
    }
    }
}