using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class ParkingBoy
    {
        private ParkingLot parkingLot;

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public string Park(string carNumber)
        {
            string ticket = parkingLot.Park(carNumber);
            return ticket;
        }

        public string FetchCar(string ticket = null)
        {
            string carNumber = parkingLot.FetchCar(ticket);
            return carNumber;
        }
    }
}
