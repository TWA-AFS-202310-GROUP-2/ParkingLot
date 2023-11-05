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
        [InlineData(5, 10, "Car1")]
        public void Should_ParkingBoy_return_car_When_fetch_Given_ticket(int lot1, int lot2, string carName)
        {
            //Given
            List<ParkingLots> parkingLots = new List<ParkingLots>
            {
                new ParkingLots(lot1),
                new ParkingLots(lot2),
            };
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            Ticket ticket = parkingBoy.Park(parkingLots, carName);
            //when
            string car = parkingBoy.Fetch(parkingLots, ticket);
            //then
            Assert.Equal("Car1", car);
        }

        [Theory]
        [InlineData(5, 10, "Car1", "Car2")]
        public void Should_ParkingBoy_return_correct_cars_When_fetch_cars_Given_tickets(int lot1, int lot2, string carName1, string carName2)
        {
            //Given
            List<ParkingLots> parkingLots = new List<ParkingLots>
            {
                new ParkingLots(lot1),
                new ParkingLots(lot2),
            };
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            Ticket ticke1 = parkingBoy.Park(parkingLots, carName1);
            Ticket ticke2 = parkingBoy.Park(parkingLots, carName2);
            //When
            string car1 = parkingBoy.Fetch(parkingLots, ticke1);
            string car2 = parkingBoy.Fetch(parkingLots, ticke2);
            //Then
            Assert.Equal("Car1", car1);
            Assert.Equal("Car2", car2);
        }

        [Theory]
        [InlineData(5, 10, "Car1", "Ticket 1")]
        public void Should_ParkingBoy_throw_WrongTicketException_When_fetch_cars_Given_wrong_tickets(int lot1, int lot2, string carName1, string ticketName)
        {
            //Given
            List<ParkingLots> parkingLots = new List<ParkingLots>
            {
                new ParkingLots(lot1),
                new ParkingLots(lot2),
            };
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            Ticket ticket = parkingBoy.Park(parkingLots, carName1);
            Ticket givenTicket = new Ticket { TicketName = ticketName };
            //When
            Action action = () => parkingBoy.Fetch(parkingLots, givenTicket);
            //Then
            var exception = Assert.Throws<WrongTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData(5, 10, "Car1")]
        public void Should_ParkingBoy_throw_WrongTicketException_When_fetch_cars_Given_null_tickets(int lot1, int lot2, string carName1)
        {
            //Given
            List<ParkingLots> parkingLots = new List<ParkingLots>
            {
                new ParkingLots(lot1),
                new ParkingLots(lot2),
            };
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            Ticket ticket = parkingBoy.Park(parkingLots, carName1);
            Ticket givenTicket = new Ticket { TicketName = null };
            //When
            Action action = () => parkingBoy.Fetch(parkingLots, givenTicket);
            //Then
            var exception = Assert.Throws<WrongTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData(5, 10, "Car1")]
        public void Should_ParkingBoy_throw_WrongTicketException_When_fetch_cars_Given_an_used_ticket(int lot1, int lot2, string carName1)
        {
            //Given
            List<ParkingLots> parkingLots = new List<ParkingLots>
            {
                new ParkingLots(lot1),
                new ParkingLots(lot2),
            };
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            Ticket ticke1 = parkingBoy.Park(parkingLots, carName1);
            string car = parkingBoy.Fetch(parkingLots, ticke1);
            //When
            Action action = () => parkingBoy.Fetch(parkingLots, ticke1);
            //Then
            var exception = Assert.Throws<WrongTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData(5, 10, "Car1", "Car100")]
        public void Should_ParkingBoy_throw_NoPositionException_When_park_cars_Given_more_than_10_cars(int lot1, int lot2, string carName1, string moreCarName)
        {
            //Given
            List<ParkingLots> parkingLots = new List<ParkingLots>
            {
                new ParkingLots(lot1),
                new ParkingLots(lot2),
            };
            ParkingBoy parkingBoy = new ParkingBoy(parkingLots);
            for (int i = 0; i < lot1 + lot2; i++)
            {
                parkingBoy.Park(parkingLots, $"Car {i}");
            }

            //When
            Action action = () => parkingBoy.Park(parkingLots, moreCarName);
            //Then
            var exception = Assert.Throws<NoPositionException>(action);
            Assert.Equal("No available position.", exception.Message);
        }
    }
}
