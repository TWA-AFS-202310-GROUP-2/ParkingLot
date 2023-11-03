using System.Collections.Generic;
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
            if (string.IsNullOrEmpty(ticket))
            {
                return "Invalid ticket";
            }
            if (ticket2Car.ContainsKey(ticket))
            {
                car = ticket2Car[ticket];
                ticket2Car.Remove(ticket);
            }
            else
            {
                car = "No car";
            }
            return car;
        }

        public string Park(string car)
        {
            if (parkingCapacity == 0)
            {
                return "No capacity";
            }

            if (string.IsNullOrEmpty(car)||ticket2Car.FirstOrDefault(tc => tc.Value == car).Key != null)
            {
                return "Error car";
            }
            string ticket = "T-"+car;
            ticket2Car.Add(ticket,car);
            parkingCapacity--;
            return ticket;
        }
    }
}
