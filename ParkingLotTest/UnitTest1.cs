namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Should_return_car_When_fetch_Given_ticket()
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            string ticket = parkingLots.Park("Car");
            //when
            string car = parkingLots.Fetch(ticket);
            //then
            Assert.Equal("Car", car);
        }
    }
}
