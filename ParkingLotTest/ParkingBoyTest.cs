using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot;
using Xunit;
using static ParkingLot.ParkingLots;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Theory]
        [InlineData("Car1")]
        public void Should_ParkingBoy_return_car_When_fetch_Given_ticket(string carName)
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            Ticket ticket = parkingBoy.ParkingLots.Park(carName);
            //when
            string car = parkingBoy.ParkingLots.Fetch(ticket);
            //then
            Assert.Equal("Car1", car);
        }

        [Theory]
        [InlineData("Car1", "Car2")]
        public void Should_ParkingBoy_return_correct_cars_When_fetch_cars_Given_tickets(string carName1, string carName2)
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            Ticket ticke1 = parkingBoy.ParkingLots.Park(carName1);
            Ticket ticke2 = parkingBoy.ParkingLots.Park(carName2);
            //When
            string car1 = parkingBoy.ParkingLots.Fetch(ticke1);
            string car2 = parkingBoy.ParkingLots.Fetch(ticke2);
            //Then
            Assert.Equal("Car1", car1);
            Assert.Equal("Car2", car2);
        }

        [Theory]
        [InlineData("Car1", "Ticket 1")]
        public void Should_ParkingBoy_throw_WrongTicketException_When_fetch_cars_Given_wrong_tickets(string carName1, string ticketName)
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            Ticket ticket = parkingBoy.ParkingLots.Park(carName1);
            Ticket givenTicket = new Ticket { TicketName = ticketName };
            //When
            Action action = () => parkingBoy.ParkingLots.Fetch(givenTicket);
            //Then
            var exception = Assert.Throws<WrongTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData("Car1")]
        public void Should_ParkingBoy_throw_WrongTicketException_When_fetch_cars_Given_null_tickets(string carName1)
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            Ticket ticket = parkingBoy.ParkingLots.Park(carName1);
            Ticket givenTicket = new Ticket { TicketName = null };
            //When
            Action action = () => parkingBoy.ParkingLots.Fetch(givenTicket);
            //Then
            var exception = Assert.Throws<WrongTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData("Car1")]
        public void Should_ParkingBoy_throw_WrongTicketException_When_fetch_cars_Given_an_used_ticket(string carName1)
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            Ticket ticke1 = parkingBoy.ParkingLots.Park(carName1);
            string car = parkingBoy.ParkingLots.Fetch(ticke1);
            //When
            Action action = () => parkingBoy.ParkingLots.Fetch(ticke1);
            //Then
            var exception = Assert.Throws<WrongTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData("Car1", "Car100")]
        public void Should_ParkingBoy_throw_NoPositionException_When_park_cars_Given_more_than_10_cars(string carName1, string moreCarName)
        {
            //Given
            ParkingLots parkingLots = new ParkingLots();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            for (int i = 0; i < 10; i++)
            {
                parkingBoy.ParkingLots.Park($"Car {i}");
            }

            //When
            Action action = () => parkingBoy.ParkingLots.Park(moreCarName);
            //Then
            var exception = Assert.Throws<NoPositionException>(action);
            Assert.Equal("No available position.", exception.Message);
        }
    }
}
