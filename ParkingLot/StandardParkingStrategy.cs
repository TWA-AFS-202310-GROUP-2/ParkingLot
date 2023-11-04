using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class StandardParkingStrategy : IParkingStrategy
    {
        public string ParkCar(List<ParkingLots> parkingLots, string car)
        {
            foreach (var lot in parkingLots)
            {
                if (lot.HasAvailableSpace())
                {
                    return lot.Park(car);
                }
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
