using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingLot;

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

        // User Story 2: AC 1
        [Theory]
        [InlineData("123")]
        public void Should_get_no_car_throw_error_msg_when_fetch_car_given_wrong_ticket(string wrongticket)
        {
            //Given
            ParkingLots parkingLot = new ParkingLots();
            //When
            string car = parkingLot.Fetch(wrongticket);
            //Then
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(wrongticket));
            Assert.Equal("Unrecognized parking ticket", wrongTicketException.Message);
        }
    }
}
