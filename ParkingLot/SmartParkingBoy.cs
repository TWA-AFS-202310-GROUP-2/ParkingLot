using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class SmartParkingBoy : StandardParkingBoy
    {
        //private List<ParkingLot> parkingLotList;

        public SmartParkingBoy(List<ParkingLot> parkingLotList) : base(parkingLotList)
        {
            //this.parkingLotList = parkingLotList;
        }

        public string Park(string carNumber)
        {
            var lotWithMostEmptySpaces = ParkingLotList.OrderByDescending(lot => lot.GetAvailableSpaces()).FirstOrDefault();
            if (lotWithMostEmptySpaces == null)
            {
                throw new FullCapacityException("No available position.");
            }

            return lotWithMostEmptySpaces.Park(carNumber);
        }

        //public string FetchCar(string ticket = null)
        //{
        //    foreach (var parkingLot in parkingLotList)
        //    {
                //try
                //{
                //    string carNumber = parkingLot.FetchCar(ticket);
                //    return carNumber;
                //}
                //catch (WrongTicketException wrongTicketException)
                //{
                //    continue;
                //}

            //    if (ticket == null || parkingLot.IsContainTheCar(ticket))
            //    {
            //        string carNumber = parkingLot.FetchCar(ticket);
            //        return carNumber;
            //    }
            //}

            //throw new WrongTicketException("Unrecognized parking ticket.");
        //}
    }
}
