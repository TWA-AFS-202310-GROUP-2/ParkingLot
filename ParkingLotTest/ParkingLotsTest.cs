namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingLotsTest
    {
        [Fact]
        public void Should_return_car_When_fetch_Given_ticket()
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            string ticket = parkingLots.Park("Car test");
            //when
            string car = parkingLots.Fetch(ticket);
            //then
            Assert.Equal("Car test", car);
        }

        [Fact]
        public void Should_return_correct_cars_When_fetch_cars_Given_tickets()
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            string ticke1 = parkingLots.Park("Car 1");
            string ticke2 = parkingLots.Park("Car 2");
            //When
            string car1 = parkingLots.Fetch(ticke1);
            string car2 = parkingLots.Fetch(ticke2);
            //Then
            Assert.Equal("Car 1", car1);
            Assert.Equal("Car 2", car2);
        }
    }
}
