using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingStrategy : IParkingStrategy
    {
        private int count;
        public string FetchCar(List<ParkingLots> parkingLots, string ticket)
        {
            foreach (var lot in parkingLots)
            {
                var car = lot.Fetch(ticket);
                if (car != null)
                {
                    return car;
                }
            }

            return null;
        }

        public string ParkCar(List<ParkingLots> parkingLots, string car)
        {
            foreach (var lot in parkingLots)
            {
                count += lot.PositionCapacity();
            }

            if (count == 0)
            {
                throw new UnAvailablePositionException("No available position.");
            }

            // Order parking lots by available space
            var lotWithMostSpace = parkingLots.OrderByDescending(lot => lot.PositionCapacity()).First();
            return lotWithMostSpace.Park(car);
        }
    }
}
