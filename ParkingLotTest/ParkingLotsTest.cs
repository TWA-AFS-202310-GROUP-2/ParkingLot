namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;
    using static ParkingLot.ParkingLots;

    public class ParkingLotsTest
    {
        [Fact]
        public void Should_return_car_When_fetch_Given_ticket()
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            Ticket ticket = parkingLots.Park("Car test");
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
            Ticket ticke1 = parkingLots.Park("Car 1");
            Ticket ticke2 = parkingLots.Park("Car 0000");
            //When
            string car1 = parkingLots.Fetch(ticke1);
            string car2 = parkingLots.Fetch(ticke2);
            //Then
            Assert.Equal("Car 1", car1);
            Assert.Equal("Car 0000", car2);
        }

        [Fact]
        public void Should_return_no_cars_When_fetch_cars_Given_wrong_tickets()
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            parkingLots.Park("Car 1");
            Ticket givenTicket = new Ticket { TicketName = "Ticket 1" };
            //When
            string car1 = parkingLots.Fetch(givenTicket);
            //Then
            Assert.Equal("This ticket is wrong", car1);
        }

        [Fact]
        public void Should_return_no_cars_When_fetch_cars_Given_null_tickets()
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            parkingLots.Park("Car 1");
            Ticket givenTicket = new Ticket { TicketName = null };
            //When
            string car1 = parkingLots.Fetch(givenTicket);
            //Then
            Assert.Equal("This ticket does not exist", car1);
        }

        [Fact]
        public void Should_return_no_cars_When_fetch_cars_Given_an_used_ticket()
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            Ticket ticke1 = parkingLots.Park("Car 1");
            parkingLots.Fetch(ticke1);
            //When
            string sameCar = parkingLots.Fetch(ticke1);
            //Then
            Assert.Equal("This ticket has been used", sameCar);
        }
    }
}
