using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static ParkingLot.ParkingLots;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingStrategy
    {
        public SmartParkingBoy(List<ParkingLots> parkingLots) : base(parkingLots)
        {
        }

        public override Ticket Park(List<ParkingLots> parkingLots, string car)
        {
            var lotWithMostSpace = parkingLots.OrderByDescending(lot => lot.RemainingParking).FirstOrDefault();

            if (lotWithMostSpace == null)
            {
                throw new NoPositionException("No available position.");
            }

            Ticket ticket = lotWithMostSpace.Park(car);
            ticket.PakingLotName = lotWithMostSpace.Number;
            return ticket;
        }
    }
}
