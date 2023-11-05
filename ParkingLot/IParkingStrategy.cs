using System.Collections.Generic;
namespace ParkingLot
{
    public interface IParkingStrategy
    {
        Ticket Park(IEnumerable<ParkingLot> parkingLots, Car car);
        Car Fetch(IEnumerable<ParkingLot> parkingLots, Ticket ticket);
    }
}