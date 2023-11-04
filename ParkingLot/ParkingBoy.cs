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

        public Ticket Park(List<ParkingLots> parkingLots, string car)
        {
            foreach (var lot in parkingLots.Where(lot => lot.HasPosition()))
            {
                return lot.Park(car);
            }

            throw new NoPositionException("No available position.");
        }

        public string Fetch(List<ParkingLots> parkingLots, Ticket ticket)
        {
            return Fetch(parkingLots, ticket);
        }
    }
}