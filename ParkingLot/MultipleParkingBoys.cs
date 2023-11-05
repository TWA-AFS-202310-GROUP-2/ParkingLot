using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParkingLot.ParkingLots;

namespace ParkingLot
{
    public class MultipleParkingBoys
    {
        private IParkingStrategy parkingStrategy;
        private List<ParkingLots> parkingLots;

        public MultipleParkingBoys(List<ParkingLots> parkingLots, IParkingStrategy parkingStrategy)
        {
            this.parkingStrategy = parkingStrategy;
            this.parkingLots = parkingLots;
        }

        public void ChangeStrategy(SmartParkingBoy smartstrategy)
        {
            this.parkingStrategy = smartstrategy;
        }

        public Ticket Park(List<ParkingLots> parkingLots, string car)
        {
            return parkingStrategy.Park(parkingLots, car);
        }

        public string Fetch(List<ParkingLots> parkingLots, Ticket ticket)
        {
            return parkingStrategy.Fetch(parkingLots, ticket);
        }
    }
}
