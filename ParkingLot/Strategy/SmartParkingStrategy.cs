using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Strategy
{
    public class SmartParkingStrategy : IParkingStrategy
    {
        public string FetchCar(List<ParkingLot> parkingLots, string ticket)
        {
            foreach (var parkingLot in parkingLots)
            {
                try
                {
                    string carNumber = parkingLot.FetchCar(ticket);
                    return carNumber;
                }
                catch (WrongTicketException wrongTicketException)
                {
                    continue;
                }
            }

            throw new WrongTicketException("Unrecognized parking ticket.");
        }

        public string Park(List<ParkingLot> parkingLots, string carNumber)
        {
            var lotWithMostEmptySpaces = parkingLots.OrderByDescending(lot => lot.GetAvailableSpaces()).FirstOrDefault();
            if (lotWithMostEmptySpaces == null)
            {
                throw new FullCapacityException("No available position.");
            }

            return lotWithMostEmptySpaces.Park(carNumber);
        }
    }
}
