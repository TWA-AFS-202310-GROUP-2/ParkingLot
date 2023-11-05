using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static ParkingLot.ParkingLots;

namespace ParkingLot
{
    public class ParkingBoy : ParkingStrategy
    {
        public ParkingBoy(List<ParkingLots> parkingLots) : base(parkingLots)
        {
        }
    }
}