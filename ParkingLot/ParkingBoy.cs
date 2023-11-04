using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static ParkingLot.ParkingLots;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private ParkingLots parkingLots;
        public ParkingBoy(ParkingLots parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public ParkingLots ParkingLots { get => parkingLots; set => parkingLots = value; }
    }
}
