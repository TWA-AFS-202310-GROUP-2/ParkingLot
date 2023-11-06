using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class StandardParkingBoy
    {
        public StandardParkingBoy(List<ParkingLot> parkingLotList)
        {
            this.ParkingLotList = parkingLotList;
        }

        protected List<ParkingLot> ParkingLotList { get; set; }

        public string Park(string carNumber)
        {
            foreach (var parkingLot in ParkingLotList)
            {
                //try
                //{
                //    string ticket = parkingLot.Park(carNumber);
                //    return ticket;
                //}
                //catch (FullCapacityException fullCapacityException)
                //{
                //    continue;
                //}
                if (!parkingLot.IsFull())
                {
                    string ticket = parkingLot.Park(carNumber);
                    return ticket;
                }
            }

            throw new FullCapacityException("No available position.");
        }

        public string FetchCar(string ticket = null)
        {
            foreach (var parkingLot in ParkingLotList)
            {
                //try
                //{
                //    string carNumber = parkingLot.FetchCar(ticket);
                //    return carNumber;
                //}
                //catch (WrongTicketException wrongTicketException)
                //{
                //    continue;
                //}
                if (ticket == null || parkingLot.IsContainTheCar(ticket))
                {
                    string carNumber = parkingLot.FetchCar(ticket);
                    return carNumber;
                }
            }

            throw new WrongTicketException("Unrecognized parking ticket.");
        }
    }
}
