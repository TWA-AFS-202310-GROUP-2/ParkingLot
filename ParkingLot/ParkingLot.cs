using System.Collections.Generic;

namespace Parking
{
    using System;
    public class ParkingLot
    {
        private string car;
        private Dictionary<string,string> ticket2Car = new Dictionary<string, string>();

        public ParkingLot() { }

        public string fetch(string ticket)
        {
            string car;
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
            string ticket = "T-"+car;
            ticket2Car.Add(ticket,car);
            return ticket;
        }
    }
}
