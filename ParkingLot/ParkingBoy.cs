using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private readonly IEnumerable<ParkingLot> parkingLots;
        private IParkingStrategy parkingStrategy;
        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLots = new List<ParkingLot> { parkingLot };
            this.parkingStrategy = new StandardParkingStrategy();
        }

        public ParkingBoy(IEnumerable<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots.ToList();
            this.parkingStrategy = new StandardParkingStrategy();
        }

        public ParkingBoy(IEnumerable<ParkingLot> parkingLots, IParkingStrategy parkingStrategy)
        {
            this.parkingLots = parkingLots;
            this.parkingStrategy = parkingStrategy;
        }

        protected IEnumerable<ParkingLot> ParkingLots
        {
             get
             {
                return parkingLots;
             }
        }

        public Ticket Park(Car car)
        {
            return parkingStrategy.Park(parkingLots, car);
        }

        public Car Fetch(Ticket ticket)
        {
            return parkingStrategy.Fetch(parkingLots, ticket);
        }

        public void SetParkingStrategy(IParkingStrategy newStrategy)
        {
            this.parkingStrategy = newStrategy;
        }
    }
}
