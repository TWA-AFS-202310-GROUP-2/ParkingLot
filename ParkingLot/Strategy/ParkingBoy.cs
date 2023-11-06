using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Strategy
{
    public class ParkingBoy
    {
        private IParkingStrategy parkingStrategy;
        private List<ParkingLot> parkingLotList;

        public ParkingBoy(IParkingStrategy strategy, List<ParkingLot> parkingLotList)
        {
            parkingStrategy = strategy;
            this.parkingLotList = parkingLotList;
        }

        public string Park(string carNumber)
        {
            return parkingStrategy.Park(parkingLotList, carNumber);
        }

        public string FetchCar(string ticket)
        {
            return parkingStrategy.FetchCar(parkingLotList, ticket);
        }
    }
}
