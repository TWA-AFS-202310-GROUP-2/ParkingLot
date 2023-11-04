using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private ParkingLot parkingLot;
        public ParkingBoy()
        {
            parkingLot = new ParkingLot(10);
        }

        public Ticket Park(Car car)
        {
            if (car == null)
            {
                return null;
            }

            if (parkingLot.ParkedCars.Count >= parkingLot.Capacity)
            {
                throw new NoPositionException("No available position.");
            }

            var ticket = new Ticket();
            parkingLot.ParkedCars.Add(ticket, car);
            return ticket;
        }

        public Car Fetch(Ticket ticket)
        {
            if (ticket == null || !parkingLot.ParkedCars.TryGetValue(ticket, out var car))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            parkingLot.ParkedCars.Remove(ticket);
            return car;
        }
    }
}
