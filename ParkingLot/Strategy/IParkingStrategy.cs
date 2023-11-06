using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Strategy
{
    public interface IParkingStrategy
    {
        string Park(List<ParkingLot> parkingLots, string carNumber);
        string FetchCar(List<ParkingLot> parkingLots, string ticket);
    }
}
