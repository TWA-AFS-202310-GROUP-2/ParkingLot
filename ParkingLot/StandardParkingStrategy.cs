using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class StandardParkingStrategy : IParkingStrategy
    {
        private int count = 0;
        public string ParkCar(List<ParkingLots> parkingLots, string car)
        {
            foreach (var lot in parkingLots)
            {
                count += lot.PositionCapacity();
                if (lot.HasAvailableSpace())
                {
                    return lot.Park(car);
                }
            }

            if (count == 0)
            {
                throw new UnAvailablePositionException("No available position.");
            }

            return null;
        }

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
    }
}
