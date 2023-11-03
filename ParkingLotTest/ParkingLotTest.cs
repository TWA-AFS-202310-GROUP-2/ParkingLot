using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingLot;
using System.Runtime.ConstrainedExecution;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        // User story 1: AC 1
        [Fact]
        public void Should_get_the_same_car_when_fetch_cat_by_ticket()
        {
            //Given
            ParkingLots parkingLot = new ParkingLots();
            string ticket = parkingLot.Park("car");
            //When
            string car = parkingLot.Fetch(ticket);
            //Then
            Assert.Equal("car", car);
        }

        // User Story 1: AC2
        [Fact]
        public void Should_get_correct_car_when_fetch_car_given_corresponding_ticket()
        {
            //Given
            ParkingLots parkingLot = new ParkingLots();
            string ticket1 = parkingLot.Park("car1");
            //When
            string car1 = parkingLot.Fetch(ticket1);

            Assert.Equal("car1", car1);
        }
        [Fact]
        public void Should_get_correct_car_when_fetch_two_car_given_each_corresponding_ticket()
        {
            //Given
            ParkingLots parkingLot = new ParkingLots();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");
            //When
            string car1 = parkingLot.Fetch(ticket1);
            string car2 = parkingLot.Fetch(ticket2);

            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        // User Story 1: AC 3
        [Theory]
        [InlineData(null)]
        [InlineData("123")]
        public void Should_get_no_car_when_fetch_car_given_wrong_or_null_ticket(string wrongticket)
        {
            //Given
            ParkingLots parkingLot = new ParkingLots();
            string wrongTicket = wrongticket;
            //When
            string car = parkingLot.Fetch(wrongTicket);

            Assert.Null(car);
        }

        // User Story 1: AC 4
        [Fact]
        public void Should_get_no_car_when_fetch_car_given_used_ticket()
        {
            //Given
            ParkingLots parkingLot = new ParkingLots();
            string ticket1 = parkingLot.Park("car1");
            //When
            parkingLot.Fetch(ticket1);

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket1));
            Assert.Equal("Unrecognized parking ticket", wrongTicketException.Message);
        }

        // User Story 1: AC 5
        [Fact]
        public void Should_not_get_ticket_when_park_given_parkinglot_capacity()
        {
            // Given
            var parkingLot = new ParkingLots(1);
            // When
            string ticket = parkingLot.Park("car1");
            // Then
            Assert.Null(ticket);
        }
    }
}
