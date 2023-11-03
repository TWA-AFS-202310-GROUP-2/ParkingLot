﻿using System.Collections.Generic;
using System.Linq;

namespace Parking
{
    using System;
    public class ParkingLot
    {
        private int parkingCapacity = 10;
        private Dictionary<string,string> ticket2Car = new Dictionary<string, string>();

        public ParkingLot() { }

        public string fetch(string ticket)
        {
            string car;
            if (!ticket2Car.ContainsKey(ticket)||string.IsNullOrEmpty(ticket))
            {
                throw new WrongTicketExecption("Unrecognized parking ticket.");
            }

            car = ticket2Car[ticket];
            ticket2Car.Remove(ticket);
            return car;
        }

        public string Park(string car)
        {
            if (parkingCapacity == 0)
            {
                throw new NoCapacityExecption("No available position");
            }

            if (string.IsNullOrEmpty(car)||ticket2Car.FirstOrDefault(tc => tc.Value == car).Key != null)
            {
                return "";
            }
            string ticket = "T-"+car;
            ticket2Car.Add(ticket,car);
            parkingCapacity--;
            return ticket;
        }
    }
}