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
            string ticket = null;
            var lotWithMostEmptySpaces = parkingLotList.OrderByDescending(lot => lot.GetAvailableSpaces()).FirstOrDefault();
            if (lotWithMostEmptySpaces == null)
            {
                throw new FullCapacityException("No available position.");
            }

            return lotWithMostEmptySpaces.Park(ticket);
        }

        public string FetchCar(string ticket = null)
        {
            string carNumber = null;
            foreach (var parkingLot in parkingLotList)
            {
                try
                {
                    carNumber = parkingLot.FetchCar(ticket);
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
