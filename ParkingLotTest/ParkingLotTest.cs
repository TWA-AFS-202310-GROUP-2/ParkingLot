namespace ParkingLotTest
{
    using Parking;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_the_same_car_when_fetch_car_by_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            string car = parkingLot.fetch(ticket);

            Assert.Equal("car",car);
        }

        [Fact]
        public void Should_get_the_correct_car_when_fetch_car_by_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();

            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");
            string car1 = parkingLot.fetch(ticket1);
            string car2 = parkingLot.fetch(ticket2);
            Assert.Equal("car1", car1);
            Assert.Equal("car2",car2);
        }

        [Fact]
        public void Should_get_no_car_when_fetch_car_by_wrong_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();

            string ticket1 = parkingLot.Park("car1");
            string car1 = parkingLot.fetch("car2");
            Assert.Equal("No car", car1);
        }
    }
}
