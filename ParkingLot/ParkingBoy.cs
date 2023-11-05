namespace ParkingLot
{
    public class ParkingBoy
    {
        private readonly ParkingLot parkingLot;

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public Ticket Park(Car car)
        {
            return this.parkingLot.Park(car);
        }

        public Car Fetch(Ticket ticket)
        {
            return this.parkingLot.Fetch(ticket);
        }
    }
}
