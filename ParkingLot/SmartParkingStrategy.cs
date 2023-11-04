using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingStrategy : IParkingStrategy
    {
        public Ticket Park(Car car, List<ParkingLot> parkingLots)
        {
            if (car == null)
            {
                return null;
            }

            if (parkingLots[0].ParkedCars.Count + parkingLots[1].ParkedCars.Count >= parkingLots[0].Capacity + parkingLots[1].Capacity)
            {
                throw new NoPositionException("No available position.");
            }

            var ticket = new Ticket();

            if (parkingLots[0].Capacity - parkingLots[0].ParkedCars.Count >= parkingLots[1].Capacity - parkingLots[1].ParkedCars.Count)
            {
                parkingLots[0].ParkedCars.Add(ticket, car);
            }
            else
            {
                parkingLots[1].ParkedCars.Add(ticket, car);
            }

            return ticket;
        }

        public Car Fetch(Ticket ticket, List<ParkingLot> parkingLots)
        {
            if (ticket == null || (!parkingLots[0].ParkedCars.TryGetValue(ticket, out var car) && !parkingLots[1].ParkedCars.TryGetValue(ticket, out car)))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            if (parkingLots[0].ParkedCars.TryGetValue(ticket, out car))
            {
                parkingLots[0].ParkedCars.Remove(ticket);
            }
            else if (parkingLots[1].ParkedCars.TryGetValue(ticket, out car))
            {
                parkingLots[1].ParkedCars.Remove(ticket);
            }

            return car;
        }
    }
}
