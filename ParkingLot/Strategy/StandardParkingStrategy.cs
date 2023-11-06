using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Strategy
{
    public class StandardParkingStrategy : IParkingStrategy
    {
        public string FetchCar(List<ParkingLot> parkingLots, string ticket)
        {
            foreach (var parkingLot in parkingLots)
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

        public string Park(List<ParkingLot> parkingLots, string carNumber)
        {
            foreach (var parkingLot in parkingLots)
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
    }
}
