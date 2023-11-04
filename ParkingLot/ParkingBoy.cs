using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static ParkingLot.ParkingLots;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private List<ParkingLots> parkingLots;
        public ParkingBoy(List<ParkingLots> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public Ticket Park(List<ParkingLots> parkingLots, string car)
        {
            foreach (var lot in parkingLots)
            {
                if (lot.HasPosition())
                {
                    return lot.Park(car);
                }
            }

            throw new NoPositionException("No available position.");
        }

        public string Fetch(List<ParkingLots> parkingLots, Ticket ticket)
        {
            foreach (var lot in parkingLots)
            {
                var car = lot.Fetch(ticket);
                if (car != null)
                {
                    return car;
                }
            }

            throw new WrongTicketException("Unrecognized parking ticket.");
        }
    }
}