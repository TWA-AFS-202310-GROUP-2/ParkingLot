using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private IParkingStrategy parkingStrategy;
        private List<ParkingLot> parkingLots;

        public ParkingBoy(IParkingStrategy parkingStrategy, List<ParkingLot> parkingLots)
        {
            this.parkingStrategy = parkingStrategy;
            this.parkingLots = parkingLots;
        }

        public Ticket Park(Car car)
        {
            return parkingStrategy.Park(car, parkingLots);
        }

        public Car Fetch(Ticket ticket)
        {
            return parkingStrategy.Fetch(ticket, parkingLots);
        }
    }
}
