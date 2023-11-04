namespace ParkingLotTest
{
    using ParkingLot;
    using System;
    using Xunit;
    using static ParkingLot.ParkingLots;
    using static System.Collections.Specialized.BitVector32;

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
        public void Should_throw_WrongTicketException_When_fetch_cars_Given_wrong_tickets()
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            parkingLots.Park("Car 1");
            Ticket givenTicket = new Ticket { TicketName = "Ticket 1" };
            //When
            Action action = () => parkingLots.Fetch(givenTicket);
            //Then
            var exception = Assert.Throws<WrongTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_WrongTicketException_When_fetch_cars_Given_null_tickets()
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            parkingLots.Park("Car 1");
            Ticket givenTicket = new Ticket { TicketName = null };
            //When
            Action action = () => parkingLots.Fetch(givenTicket);
            //Then
            var exception = Assert.Throws<WrongTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_WrongTicketException_When_fetch_cars_Given_an_used_ticket()
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            Ticket ticke1 = parkingLots.Park("Car 1");
            parkingLots.Fetch(ticke1);
            //When
            Action action = () => parkingLots.Fetch(ticke1);
            //Then
            var exception = Assert.Throws<WrongTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_NoPositionException_When_park_cars_Given_more_than_10_cars()
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            for (int i = 0; i < 10; i++)
            {
                parkingLots.Park($"Car {i}");
            }

            //When
            Action action = () => parkingLots.Park("Car 100");
            //Then
            var exception = Assert.Throws<NoPositionException>(action);
            Assert.Equal("No available position.", exception.Message);
        }
    }
}
