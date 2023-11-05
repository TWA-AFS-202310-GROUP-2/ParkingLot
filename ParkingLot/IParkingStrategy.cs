using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static ParkingLot.ParkingLots;

namespace ParkingLot
{
    public interface IParkingStrategy
    {
        Ticket Park(List<ParkingLots> parkingLots, string car);
        string Fetch(List<ParkingLots> parkingLots, Ticket ticket);
    }
}
