namespace Parking
{
    using System;
    public class ParkingLot
    {
        private string car;
        public ParkingLot() { }

        public string fetch(string ticket)
        {
            return car;
        }

        public string Park(string car)
        {
            this.car = car;
            return "q";
        }
    }
}
