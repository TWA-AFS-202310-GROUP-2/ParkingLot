using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public interface IParkingStrategy
    {
        string ParkCar(List<ParkingLots> parkingLots, string car);
        string FetchCar(List<ParkingLots> parkingLots, string ticket);
    }
}
