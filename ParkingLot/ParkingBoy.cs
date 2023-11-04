using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private ParkingLot parkingLot1;
        private ParkingLot parkingLot2;

        public ParkingBoy()
        {
            parkingLot1 = new ParkingLot(10);
            parkingLot2 = new ParkingLot(20);
        }

        public Ticket Park(Car car)
        {
            if (car == null)
            {
                return null;
            }

            if (parkingLot1.ParkedCars.Count + parkingLot2.ParkedCars.Count >= parkingLot1.Capacity + parkingLot2.Capacity)
            {
                throw new NoPositionException("No available position.");
            }

            var ticket = new Ticket();

            if (parkingLot1.Capacity - parkingLot1.ParkedCars.Count >= parkingLot2.Capacity - parkingLot2.ParkedCars.Count)
            {
                parkingLot1.ParkedCars.Add(ticket, car);
            }
            else
            {
                parkingLot2.ParkedCars.Add(ticket, car);
            }

            return ticket;
        }

        public Car Fetch(Ticket ticket)
        {
            if (ticket == null || (!parkingLot1.ParkedCars.TryGetValue(ticket, out var car) && !parkingLot2.ParkedCars.TryGetValue(ticket, out car)))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            if (parkingLot1.ParkedCars.TryGetValue(ticket, out car))
            {
                parkingLot1.ParkedCars.Remove(ticket);
            }
            else if (parkingLot2.ParkedCars.TryGetValue(ticket, out car))
            {
                parkingLot2.ParkedCars.Remove(ticket);
            }

            return car;
        }
    }
}
