using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public interface IParkingStrategy
    {
        Ticket Park(Car car, List<ParkingLot> parkingLots);
        Car Fetch(Ticket ticket, List<ParkingLot> parkingLots);
    }
}
