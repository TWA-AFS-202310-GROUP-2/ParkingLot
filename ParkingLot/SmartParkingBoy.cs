using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class SmartParkingBoy
    {
        private List<ParkingLot> parkingLotList;

        public SmartParkingBoy(List<ParkingLot> parkingLotList)
        {
            this.parkingLotList = parkingLotList;
        }

        public string Park(string carNumber)
        {
            var lotWithMostEmptySpaces = parkingLotList.OrderByDescending(lot => lot.GetAvailableSpaces()).FirstOrDefault();
            if (lotWithMostEmptySpaces == null)
            {
                throw new FullCapacityException("No available position.");
            }

            return lotWithMostEmptySpaces.Park(carNumber);
        }

        public string FetchCar(string ticket = null)
        {
            foreach (var parkingLot in parkingLotList)
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
    }
}
