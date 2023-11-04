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
        private readonly IParkingStrategy parkingStrategy;
        private readonly List<ParkingLots> parkingLots;

        public ParkingBoy(IParkingStrategy strategy, List<ParkingLots> lots)
        {
            parkingStrategy = strategy;
            parkingLots = lots;
        }

        public ParkingBoy()
        {
        }

        public string ParkCar(string car)
        {
            return parkingStrategy.ParkCar(parkingLots, car);
        }

        public string FetchCar(string ticket)
        {
            return parkingStrategy.FetchCar(parkingLots, ticket);
        }
    }
}
