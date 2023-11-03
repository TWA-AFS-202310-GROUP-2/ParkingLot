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
    }
}
