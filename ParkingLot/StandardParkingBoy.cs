﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class StandardParkingBoy
    {
        private List<ParkingLot> parkingLotList;

        public StandardParkingBoy(List<ParkingLot> parkingLotList)
        {
            this.parkingLotList = parkingLotList;
        }

        public string Park(string carNumber)
        {
            string ticket = null;
            foreach (var parkingLot in parkingLotList)
            {
                try
                {
                    ticket = parkingLot.Park(carNumber);
                    return ticket;
                }
                catch (FullCapacityException fullCapacityException)
                {
                    continue;
                }
            }

            throw new FullCapacityException("No available position.");
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