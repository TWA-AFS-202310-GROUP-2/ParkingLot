using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotTestUserStory2
    {
        // User Story 2: AC 1
        [Theory]
        [InlineData("123")]
        public void Should_throw_error_msg_when_fetch_car_given_unrecognized_ticket(string wrongticket)
        {
            //Given
            ParkingLots parkingLot = new ParkingLots();
            //When and Then
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(wrongticket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_throw_error_msg_when_fetch_car_given_used_ticket()
        {
            //Given
            ParkingLots parkingLot = new ParkingLots();
            string ticket1 = parkingLot.Park("car1");
            //When
            parkingLot.Fetch(ticket1);

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket1));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        // User Story 2: AC 2
        [Theory]
        [InlineData(0)]
        public void Should_no_park_throw_error_msg_when_unavailable_position_given_capacity(int capacity)
        {
            //Given
            ParkingLots parkingLot = new ParkingLots(capacity);
            //When and Then
            UnAvailablePositionException unavailablePositionException = Assert.Throws<UnAvailablePositionException>(() => parkingLot.Park("car"));
            Assert.Equal("No available position.", unavailablePositionException.Message);
        }
    }
}
